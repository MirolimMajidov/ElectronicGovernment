using BankManagementSystem.Infrastructure;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.Auth;
using ElectronicGovernment.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BankManagementSystem.Services
{
    public class AuthService
    {
        private readonly EGContext _context;
        public AuthService(EGContext context)
        {
            _context = context;
        }

        public async Task<TokenInfo> Login(string username, string password)
        {
            var user = await _context.Users.Include(u => u.Roles).ThenInclude(r => r.Role).SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

            return await GeneratedJWT(user);
        }

        public async Task<TokenInfo> RefreshToken(string refreshToken)
        {
            var user = await _context.Users.Include(u => u.Roles).ThenInclude(r => r.Role).SingleOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return await GeneratedJWT(user);
        }

        async Task<TokenInfo> GeneratedJWT(User user)
        {
            if (user is null)
                throw new ArgumentException("Invalid username or password.");

            var userRoles = user.Roles?.Select(r => r.Role.Name) ?? [];

            var claims = new List<Claim> {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName)
            };

            foreach (var userRole in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, userRole));

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            var refreshToken = Guid.NewGuid().ToString();

            user.RefreshToken = refreshToken;
            _context.Update(user);
            await _context.SaveChangesAsync();

            return new TokenInfo { AccessToken = accessToken, RefreshToken = refreshToken };
        }
    }
}

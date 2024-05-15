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
            var user = await _context.Users.Include(u => u.Roles).SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

            return await GeneratedJWT(user);
        }

        public async Task<TokenInfo> RefreshToken(string refreshToken)
        {
            var user = await _context.Users.Include(u => u.Roles).SingleOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return await GeneratedJWT(user);
        }

        async Task<TokenInfo> GeneratedJWT(User user)
        {
            if (user is null)
                throw new ArgumentException("Invalid username or password.");

            var claims = new List<Claim> {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName)
            };

            foreach (var userRole in user.Roles)
            {
                string roleName;
                switch (userRole.RoleType)
                {
                    case RoleType.Admin:
                        roleName = nameof(RoleType.Admin);
                        break;
                    case RoleType.CEO:
                        roleName = nameof(RoleType.CEO);
                        break;
                    case RoleType.Lead:
                        roleName = nameof(RoleType.Lead);
                        break;
                    case RoleType.GlobalOperator:
                        roleName = nameof(RoleType.GlobalOperator);
                        break;
                    case RoleType.Operator:
                        roleName = nameof(RoleType.Operator);
                        break;
                    default:
                        roleName = nameof(RoleType.Employee);
                        break;
                }

                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }

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

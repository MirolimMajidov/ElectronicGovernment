using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ElectronicGovernment.Auth;

internal class AuthOptions
{
    public const string ISSUER = "EGServer";
    public const string AUDIENCE = "MyAuthClient";
    const string KEY = "2EC1EE51-1100-4347-BF22-EEB6CB8B0695";
    public const int LIFETIME = 30; // Expires after - 15 minutes
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}

namespace EGovernment.Web.Models;

public class AuthenticationCredential
{
    public string AccessToken { get; set; }
    public string Scopes { get; set; }
    public string TokenType { get; set; }
    public string RefreshToken { get; set; }
}
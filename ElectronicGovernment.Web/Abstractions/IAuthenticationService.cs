namespace EGovernment.Web.Abstractions;

public interface IAuthenticationService
{
    Task SignIn(string username, string password);
}
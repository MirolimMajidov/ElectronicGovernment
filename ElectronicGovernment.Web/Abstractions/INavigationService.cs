namespace EGovernment.Web.Abstractions;

public interface INavigationService
{
    void NavigateTo(string url);
    void NavigateToLoginPage();
    Uri ToAbsoluteUri(string relativeUri);
    string Uri();
}
using EGovernment.Web.Abstractions;
using Microsoft.AspNetCore.Components;

namespace EGovernment.Web.Services;

public class NavigationService : NavigationManager, INavigationService
{
    private readonly NavigationManager _navigationManager;

    public NavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public void NavigateTo(string url) => _navigationManager.NavigateTo(url);

    public void NavigateToLoginPage()
    {
        _navigationManager.NavigateTo("/login");
    }

    public new Uri ToAbsoluteUri(string relativeUri) => _navigationManager.ToAbsoluteUri(relativeUri);

    public new string Uri() => _navigationManager.Uri;
}
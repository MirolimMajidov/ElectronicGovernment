using ElectronicGovernment.Mobile.Services;
using ElectronicGovernment.Mobile.ViewModels;

namespace ElectronicGovernment.Mobile;

public static class DependencyInitializerCore
{
    public static IServiceProvider ServiceProvider { get; set; }
    public static void AddCore(this IServiceCollection services)
    {
        services.AddTransient<INavigationService, NavigationService>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<DocumentHistoryViewModel>();
    }
}
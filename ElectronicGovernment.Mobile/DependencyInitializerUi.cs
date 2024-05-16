using ElectronicGovernment.Mobile.ViewModels;
using ElectronicGovernment.Mobile.Views;
using ReactiveUI;

namespace ElectronicGovernment.Mobile;

public static class DependencyInitializerUi
{
    public static void AddUi(this IServiceCollection services)
    {
        services.AddTransient<IViewFor<HomeViewModel>, HomePage>();
        services.AddTransient<IViewFor<DocumentHistoryViewModel>, DocumentHistoryPage>();
    }
}
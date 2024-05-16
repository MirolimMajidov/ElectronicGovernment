namespace ElectronicGovernment.Mobile.ViewModels;

public class ViewModelLocator
{
    public DocumentHistoryViewModel DocumentHistoryViewModel =>
        DependencyInitializerCore.ServiceProvider.GetRequiredService<DocumentHistoryViewModel>();
    public HomeViewModel HomeViewModel
    {
        get
        {
            var homeViewModel = DependencyInitializerCore.ServiceProvider.GetRequiredService<HomeViewModel>();
            return homeViewModel;
        }
    }
}
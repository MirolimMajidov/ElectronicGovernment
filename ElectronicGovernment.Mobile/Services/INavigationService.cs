using ElectronicGovernment.Mobile.ViewModels;

namespace ElectronicGovernment.Mobile.Services;

public interface INavigationService
{
    Task NavigateAsync<TViewModel>(params (string paramaterName, object value)[] parameters)
        where TViewModel : BaseViewModel;
}
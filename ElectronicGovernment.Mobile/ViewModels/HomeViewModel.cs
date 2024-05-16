using System.Reactive;
using ElectronicGovernment.Mobile.Services;
using ReactiveUI;

namespace ElectronicGovernment.Mobile.ViewModels;

public class HomeViewModel : BaseViewModel
{
    public ReactiveCommand<Unit, Unit> NavigateDocumentHistoryCommand { get; }

    public HomeViewModel(INavigationService navigationService)
        : base(navigationService)
    {
        NavigateDocumentHistoryCommand = ReactiveCommand.CreateFromTask(NavigateDocumentHistory);
    }

    private Task NavigateDocumentHistory() => NavigationService.NavigateAsync<DocumentHistoryViewModel>();
}
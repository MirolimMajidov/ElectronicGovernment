using System.Reactive.Linq;
using ElectronicGovernment.Mobile.Services;
using ReactiveUI;

namespace ElectronicGovernment.Mobile.ViewModels;

public class BaseViewModel : ReactiveObject
{
    protected readonly INavigationService NavigationService;
    protected BaseViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    private bool _isBusy;
    private string _title;
    private bool _isRefresh;

    public bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }

    public bool IsRefresh
    {
        get => _isRefresh;
        set => this.RaiseAndSetIfChanged(ref _isRefresh, value);
    }

    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    protected void CatchObservableExceptions(params IHandleObservableErrors[] commands)
    {
        var thrownExceptions = MergeExceptionObservable(commands);
        thrownExceptions.Subscribe(OnErrorShowMessage);
    }

    private IObservable<Exception>
        MergeExceptionObservable(params IHandleObservableErrors[] handleObservableErrors) =>
        handleObservableErrors.Select(errors => errors.ThrownExceptions).Merge();

    private void OnErrorShowMessage(Exception exception)
    {
        Console.Error.WriteLine(exception.Message);
    }

    public virtual Task ViewAppearing()
    {
        return Task.CompletedTask;
    }

    public virtual Task ViewInitialized()
    {
        return Task.CompletedTask;
    }

    public virtual Task ViewDisappearing()
    {
        return Task.CompletedTask;
    }
}
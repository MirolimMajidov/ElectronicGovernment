using ElectronicGovernment.Mobile.ViewModels;
using ReactiveUI;

namespace ElectronicGovernment.Mobile.Abstractions;

public abstract class BaseContentPage<TViewModel> : ContentPage, IViewFor<TViewModel>
    where TViewModel : BaseViewModel
{
    private bool _isInit;

    object IViewFor.ViewModel
    {
        get => ViewModel;
        set => BindingContext = ViewModel = value as TViewModel;
    }

    public TViewModel ViewModel { get; set; }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        ViewModel ??= BindingContext as TViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (!_isInit)
            ViewModel?.ViewInitialized();
        ViewModel?.ViewAppearing();
        _isInit = true;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ViewModel?.ViewDisappearing();
    }

    protected override bool OnBackButtonPressed()
    {
        var result = base.OnBackButtonPressed();
        return result;
    }
}
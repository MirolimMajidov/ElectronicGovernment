using ElectronicGovernment.Mobile.ViewModels;
using ReactiveUI;

namespace ElectronicGovernment.Mobile.Services;

public class NavigationService : INavigationService
{
    public NavigationService()
    {
        
    }
    private INavigation Navigation
    {
        get
        {
            if (Shell.Current == null)
                return Application.Current.MainPage.Navigation;
            Shell.Current.Navigating -= CurrentShellOnNavigating;
            Shell.Current.Navigating += CurrentShellOnNavigating;
            return Shell.Current.Navigation;
        }
    }

    public NavigationState LastNavigationState { get; private set; }

    private void CurrentShellOnNavigating(object sender, ShellNavigatingEventArgs e)
    {
        if (e.Source is ShellNavigationSource.Pop)
            LastNavigationState = NavigationState.Pop;
        else if (e.Source is ShellNavigationSource.Push)
            LastNavigationState = NavigationState.Push;
        else
            LastNavigationState = NavigationState.PopToRoot;
    }

    public Task NavigateAsync<TViewModel>(params (string paramaterName, object value)[] parameters) where TViewModel : BaseViewModel
    {
        var view = GetView<TViewModel>(parameters);
        if (view is Page page)
        {
            return Navigation.PushAsync(page, true);
        }

        throw new ArgumentException($"{view} is not Page");
    }
    
    private IViewFor<TViewModel> GetView<TViewModel>(TViewModel viewMode) where TViewModel : BaseViewModel
    {
        var view = Resolve<IViewFor<TViewModel>>();
        ((IViewFor)view).ViewModel = viewMode;
        return view;
    }
    
    private IViewFor<TVieWModel> GetView<TVieWModel>(params (string paramaterName, object value)[] parameters)
        where TVieWModel : BaseViewModel
    {
        var viewModel = Resolve<TVieWModel>(parameters);
        return GetView(viewModel);
    }
    
    private T Resolve<T>(params (string paramaterName, object value)[] parameters) where T : class
    {
        if (parameters.Any())
            return GetService<T>(parameters);

        var serviceScope = DependencyInitializerCore.ServiceProvider.CreateScope();
        return serviceScope.ServiceProvider.GetRequiredService<T>();
    }
    
    private T GetService<T>(params (string parameterName, object value)[] givenParameters) where T : class
    {
        var constructorInfo = typeof(T).GetConstructors().First(info => info.IsPublic);

        var parameters = new List<object>();
        var serviceScope = DependencyInitializerCore.ServiceProvider.CreateScope();
        var serviceProvider = serviceScope.ServiceProvider;
        foreach (var parameterInfo in constructorInfo.GetParameters())

        {
            if (givenParameters.Any(tuple => tuple.parameterName == parameterInfo.Name))
            {
                var namedParameter = givenParameters.First(tuple => tuple.parameterName == parameterInfo.Name);
                parameters.Add(namedParameter.value);
            }
            else
            {
                var parameter = serviceProvider
                    .GetRequiredService(parameterInfo.ParameterType);
                parameters.Add(parameter);
            }
        }

        var instance = Activator.CreateInstance(typeof(T), parameters.ToArray());

        return instance as T;
    }
}
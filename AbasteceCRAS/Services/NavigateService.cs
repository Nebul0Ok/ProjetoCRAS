using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.ViewModels;

namespace AbasteceCRAS.Services;

public interface INaviationService
{
    ViewModelBase CurrentView { get;}
    void NavigateTo<T>() where T : ViewModelBase;
}

public class NavigateService : OnPropertyChangedHandler, INaviationService
{
    
    private readonly Func<Type, ViewModelBase> _viewModelFactory;
    private ViewModelBase _currentView;
    public ViewModelBase CurrentView
    {
        get { return _currentView; }
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public NavigateService(Func<Type, ViewModelBase> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
    {
        ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }
}

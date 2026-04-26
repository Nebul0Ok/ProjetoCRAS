using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Usuario UsuarioAtual { get;set;}

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged();}
        }

        public MainViewModel()
        {
            UsuarioAtual = SessionService.Instance.UsuarioLogado;
            CurrentView = new HomeViewModel();
        }
    }
}

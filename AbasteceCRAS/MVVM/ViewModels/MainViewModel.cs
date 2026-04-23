using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Usuario UsuarioAtual { get;set;}
        public DepositoViewModel Deposito;
        public HomeViewModel Home;

        public static MainViewModel Instance { get; private set;}

        


        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged();}
        }

        public MainViewModel()
        {
            UsuarioAtual = SessionService.Instance.UsuarioLogado;
            Home = new HomeViewModel();
            CurrentView = Home;
            Deposito = new DepositoViewModel();
            Instance = this;
        }

        public void AcessarDeposito()
        {
            CurrentView = Deposito;
        }

        public void AcessarHome()
        {
            CurrentView = Home;
        }

    }
}

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

        public ICommand AcessarDeposito { get; }


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
            AcessarDeposito = new RelayCommand(AcessarTelaDeposito);
        }

        public void AcessarTelaDeposito(object parameter)
        {
            CurrentView = Deposito;
        }

    }
}

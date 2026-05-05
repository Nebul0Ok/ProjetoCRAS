using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Usuario UsuarioAtual { get;set;}
        public HomeViewModel Home;
        public DepositoViewModel Deposito;
        public ItensViewModel Itens;
        public EstoqueViewModel Estoque;
        public HistoricoViewModel Historico;

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
            Deposito = new DepositoViewModel();
            Itens = new ItensViewModel();
            Historico = new HistoricoViewModel();
            Estoque = new EstoqueViewModel();
            CurrentView = Home;
            Instance = this;
        }

        public void AcessarHome()
        {
            CurrentView = Home;
        }

        public void AcessarDeposito()
        {
            CurrentView = Deposito;
        }

        public void AcessarItens()
        {
            CurrentView = Itens;
        }

        public void AcessarEstoque()
        {
            CurrentView = Estoque;
        }

        public void AcessarHistorico()
        {
            CurrentView = Historico;
        }



    }
}

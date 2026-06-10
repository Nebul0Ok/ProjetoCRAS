using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.MVVM.Views;
using AbasteceCRAS.Services;
using System.Windows;
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
        public CadastroUsuarioViewModel CadastroUsuario;

        private bool _isCordenador;
        public bool IsCordenador
        {
            get
            {
                if (SessionService.Instance.UsuarioLogado.Cargo.Equals("coordenador"))
                {
                    _isCordenador = true;
                }
                else
                {
                    _isCordenador = false;
                }

                return _isCordenador;
            }
            set
            {
                _isCordenador = value;

                OnPropertyChanged();
            }
        }

        private bool _temNotificacao;
        public bool TemNotificacao
        {
            get => _temNotificacao;
            set
            {
                _temNotificacao = value;
                OnPropertyChanged();

                
            }
        }

        private float _margemSeparator;
        public float MargemSeparator
        {
            get
            {
                if (IsCordenador)
                {
                    _margemSeparator = 0;
                }
                else
                {
                    _margemSeparator = 10;
                }
                return _margemSeparator;
            }
            set
            {
                _margemSeparator = value;
                OnPropertyChanged();
            }
        }

        private bool _notificacoesAberta;
        public bool NotificacoesAberta
        {
            get => _notificacoesAberta;
            set
            {
                _notificacoesAberta = value;
                OnPropertyChanged();

                //***************************************************************
                //*                                                             *
                //*      Se ele for verdadeiro, ou seja, se o usuario           *
                //*  realmente abriu as notificacoes ele transfere todas        *
                //*  as notificações pendentes                                  *
                //*                                                             *
                //***************************************************************

                if (_notificacoesAberta)
                {
                    while (DadosService.Instance.Notificacoes.Count > 0)
                    {
                        DadosService.Instance.AdicionarNotificacaoQueue();
                    }

                    AtualizarNotificacoes();
                }
            }
        }
        

        private Visibility _visibilidadeCadastro;
        public Visibility VisibilidadeCadastro
        {
            get
            {
                if (IsCordenador)
                {
                    _visibilidadeCadastro = Visibility.Visible;
                }
                else
                {
                    _visibilidadeCadastro = Visibility.Collapsed;
                }
                return _visibilidadeCadastro;
            }
            set
            {
                _visibilidadeCadastro = value;
                OnPropertyChanged();
            }
        }

        public ICommand AlternarNotificacoes { get; }
        public ICommand MenuLateral { get; }
        public ICommand Sair {  get; }
        public ICommand NavegarCadastrarAdmin {  get; }

        public static MainViewModel Instance { get; private set;}

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged();}
        }

        private Visibility _menuLateralVisibility = Visibility.Collapsed;
        public Visibility MenuLateralVisibility
        {
            get => _menuLateralVisibility;
            set
            {
                _menuLateralVisibility = value; OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            UsuarioAtual = SessionService.Instance.UsuarioLogado;
            Home = new HomeViewModel();
            Deposito = new DepositoViewModel();
            Itens = new ItensViewModel();
            Historico = new HistoricoViewModel();
            Estoque = new EstoqueViewModel();
            CadastroUsuario = new CadastroUsuarioViewModel();
            CurrentView = Home;
            Instance = this;

            MenuLateral = new RelayCommand(AlterarMenuLateral);
            Sair = new RelayCommand(SairSistema);

            AlternarNotificacoes = new RelayCommand(o => NotificacoesAberta = !NotificacoesAberta);

            NavegarCadastrarAdmin = new RelayCommand(AcessarCadastroUsuario);

            DadosService.Instance.VerificarValidades();
            AtualizarNotificacoes();
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

        public void AcessarCadastroUsuario(object parameter)
        {
            CurrentView = CadastroUsuario;
        }


        public void AlterarMenuLateral(object parameter)
        {

            if (MenuLateralVisibility == Visibility.Collapsed)
            {
                MenuLateralVisibility = Visibility.Visible;
            }
            else
            {
                MenuLateralVisibility = Visibility.Collapsed;
            }

        }

        public void SairSistema (object parameter)
        {
            MessageBoxResult confirmar = MessageBox.Show("Deseja deslogar?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmar == MessageBoxResult.Yes)
            {
                if(parameter is Window mainWindow)
                {
                    SessionService.Instance.UsuarioLogado = null;
                    TelaLogin t = new TelaLogin();

                    t.Show();
                    mainWindow.Close();


                }
            }
        }

        public void AtualizarNotificacoes()
        {
            TemNotificacao = DadosService.Instance.Notificacoes.Count > 0;
        }


    }
}

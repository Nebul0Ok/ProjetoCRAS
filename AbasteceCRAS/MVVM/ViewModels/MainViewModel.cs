using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Usuario UsuarioAtual { get;set;}
        
        //Construtor
        public MainViewModel(INaviationService navService)
        {
            UsuarioAtual = SessionService.Instance.UsuarioLogado;
            Navigation = navService;

            AcessarDeposito = new RelayCommand(o => { Navigation.NavigateTo<DepositoViewModel>(); }, o => true);
        }


        //N sei como definir
        private INaviationService _navigation;
        public INaviationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        //Botões
        public ICommand AcessarDeposito { get; set;}


        //Métodos
        
    }
}

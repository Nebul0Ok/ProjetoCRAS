using AbasteceCRAS.Core;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels;

public class HomeViewModel
{
    public ICommand NavegarDeposito { get;}
    public ICommand NavegarEstoque { get; }
    public ICommand NavegarItens { get; }
    public ICommand NavegarHistorico { get; }

    public HomeViewModel()
    {
        NavegarDeposito = new RelayCommand(o => MainViewModel.Instance.AcessarDeposito());
        NavegarEstoque = new RelayCommand(o => MainViewModel.Instance.AcessarEstoque());
        NavegarItens = new RelayCommand(o => MainViewModel.Instance.AcessarItens());
        NavegarHistorico = new RelayCommand(o => MainViewModel.Instance.AcessarHistorico());
    }

}

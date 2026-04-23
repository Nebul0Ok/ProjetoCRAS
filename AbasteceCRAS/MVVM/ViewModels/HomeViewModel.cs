using AbasteceCRAS.Core;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels;

public class HomeViewModel
{
    public ICommand NavegarDeposito { get;}

    public HomeViewModel()
    {
        NavegarDeposito = new RelayCommand(o => MainViewModel.Instance.AcessarDeposito());
    }

}

using AbasteceCRAS.Core;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels;

public class DepositoViewModel
{
    public ICommand RetornarParaHome { get;}

    public DepositoViewModel()
    {
        RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
    }
}

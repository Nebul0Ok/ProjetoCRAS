using AbasteceCRAS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class EstoqueViewModel
    {
        public ICommand RetornarParaHome { get; }

        public EstoqueViewModel()
        {
            RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
        }
    }
}

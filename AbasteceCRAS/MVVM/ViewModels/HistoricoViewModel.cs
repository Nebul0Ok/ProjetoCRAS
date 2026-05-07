using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class HistoricoViewModel
    {
        public ICommand RetornarParaHome { get; }

        public HistoricoViewModel()
        {

            RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
        }

    }
}

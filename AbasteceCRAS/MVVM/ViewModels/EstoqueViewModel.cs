using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class EstoqueViewModel
    {
        public ICommand RetornarParaHome { get; }
        public ICommand DiminuirLista { get; }

        public EstoqueViewModel()
        {
            RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
            VoltarHome = new RelayCommand(VoltarParaHome);
            DiminuirLista = new RelayCommand(o => DiminuirALista(o));
        }

        public ICommand VoltarHome { get; }

        public void VoltarParaHome (object juninho)
        {
            MainViewModel.Instance.AcessarHome();
        }

        public void DiminuirALista (object parameter)
        {
            var prod = parameter as Produto;

            if (prod.Expandido)
            {
                prod.Expandido = false;
            }
            else
            {
                prod.Expandido = true;
            }
        }



    }
}

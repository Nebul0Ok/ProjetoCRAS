using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class EstoqueViewModel: ViewModelBase
    {
        public ICommand RetornarParaHome { get; }
        public ICommand DiminuirLista { get; }


        private string[] _listaItens;
        public string[] ListaItens
        {
            get => _listaItens;
            set
            {
                _listaItens = value;
                OnPropertyChanged();
            }
        }

        //   Pega o nome do item que o usuario selecionou
        //  e cria uma lista com o valor de todos do 
        //  nome de todos os tipos que esse item tem
                

        private string _itemSelecionado;
        public string ItemSelecionado 
        {  
            get => _itemSelecionado;
            set
            {
                _itemSelecionado = value;

                Produto produto = DadosService.Instance.ListaProduto.FirstOrDefault(o => o.NomeItem == value);

                if (produto != null)
                {
                    ObservableCollection<string> tipos = new ObservableCollection<string>();

                    foreach (TipoDeItem tipo in produto.TipoDeItems)
                    {
                        tipos.Add(tipo.NomeTipo);
                    }

                    ListaTipos = tipos;
                }

                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _listaTipos;
        public ObservableCollection<string> ListaTipos
        {
            get => _listaTipos;
            set
            {
                _listaTipos = value;
                OnPropertyChanged();
            }
        }

        //  Pegar a variável com o valor do item selecionado
        //  Criar uma lista com os armazens que ele está
        //  Adicionar ao valor da lista que vai ser exibida


        private string _tipoSelecionado;
        public string TipoSelecionado
        {
            get => _tipoSelecionado;
            set
            {
                _tipoSelecionado = value;

                Produto prod = DadosService.Instance.ListaProduto.FirstOrDefault(o => o.NomeItem == ItemSelecionado);

                if (prod != null)
                {
                    IEnumerable<TipoDeItem> tipo = prod.TipoDeItems.Where(t => t.NomeTipo == value);

                    if(tipo != null)
                    {
                        ObservableCollection<string> deposito = new ObservableCollection<string>();

                        foreach (TipoDeItem tipos in tipo)
                        {
                            deposito.Add(tipos.DepositoAtual.Nome);
                        }

                        ListaDepositos = deposito;
                    }
                    
                }
            }
        }



        private ObservableCollection<string> _listaDepositos;
        public ObservableCollection<string> ListaDepositos
        {
            get => _listaDepositos;
            set
            {
                _listaDepositos = value;
                OnPropertyChanged();
            }
        }

        private string _depositoSelecionado;
        public string DepositoSelecionado
        {
            get => _depositoSelecionado;
            set
            {
                _depositoSelecionado = value;
            }
        }


        public EstoqueViewModel()
        {
            RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
            VoltarHome = new RelayCommand(VoltarParaHome);
            DiminuirLista = new RelayCommand(o => DiminuirALista(o));

            ListaItens = new string[DadosService.Instance.ListaProduto.Count];

            for(int i = 0; i<ListaItens.Length; i++)
            {
                ListaItens[i] = DadosService.Instance.ListaProduto[i].NomeItem;
            }
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

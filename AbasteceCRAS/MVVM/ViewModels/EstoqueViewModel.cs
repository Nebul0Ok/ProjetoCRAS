using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class EstoqueViewModel: ViewModelBase
    {
        public ICommand RetornarParaHome { get; }
        public ICommand DiminuirLista { get; }
        public ICommand SelecionarEntrada { get; }
        public ICommand SelecionarSaida {  get; }
        public ICommand VoltarHome { get; }
        public ICommand BtnConfirmarOperacao { get; }

        //Construtor
        public EstoqueViewModel()
        {
            RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
            VoltarHome = new RelayCommand(VoltarParaHome);
            DiminuirLista = new RelayCommand(o => DiminuirALista(o));
            BtnConfirmarOperacao = new RelayCommand(Operacao);
        }





        // ---------- Variáveis ----------

        //Operações

        private bool _isEntrada;
        public bool IsEntrada
        {
            get => _isEntrada;
            set
            {
                _isEntrada = value;
                OnPropertyChanged();
            }
        }

        private bool _isSaida;
        public bool IsSaida
        {
            get => _isSaida;
            set
            {
                _isSaida = value;
                OnPropertyChanged();
            }
        }

        private int _valorQuantidade;
        public int ValorQuantidade
        {
            get => _valorQuantidade;
            set
            {
                _valorQuantidade = value;
                OnPropertyChanged();
            }
        }


        //Listas

        //Cria uma cópia da
        //lista de produtos para
        //ser usado na tela
        public ObservableCollection<Produto> ListaItens { get; set; } = DadosService.Instance.ListaProduto;

        private Produto _itemSelecionado;
        public Produto ItemSelecionado
        {
            get => _itemSelecionado;
            set
            {
                _itemSelecionado = value;
                ListaTipos = value.TipoDeItems;
                OnPropertyChanged();
            }
        }

        //Precisa de um campo privado também,
        //já que ele muda toda a lista sempre
        //que o usuário seleciona um outro item
        private ObservableCollection<TipoDeItem> _listaTipos;
        public ObservableCollection<TipoDeItem> ListaTipos
        {
            get => _listaTipos;
            set
            {
                _listaTipos = value;

                
                OnPropertyChanged();
            }
        }

        private TipoDeItem _tipoSelecionado;
        public TipoDeItem TipoSelecionado
        {
            get => _tipoSelecionado;
            set
            {
                _tipoSelecionado = value;
                OnPropertyChanged();
            }
        }

        //private ObservableCollection<Deposito> _listaDeposito;
        //public ObservableCollection<Deposito> ListaDeposito
        //{
        //    get => _listaDeposito;
        //    set
        //    {
        //        _listaDeposito = value;
        //        OnPropertyChanged()
        //    }
        //}



//Funções
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


        public void Operacao(object parameter)
        {
            if (!IsEntrada && !IsSaida)
            {
                MessageBox.Show("Por favor, selecione uma operação");
            }

            Produto p = DadosService.Instance.ListaProduto.FirstOrDefault(o => o == ItemSelecionado);

            if (p == null) return;


            if (IsEntrada)
            {
                foreach (TipoDeItem prod in p.TipoDeItems)
                {
                    if (prod == TipoSelecionado)
                    {
                        prod.QuantidadeTipoEstoque += ValorQuantidade;
                        MessageBox.Show($"Quantidade de {prod.NomeTipo} alterado para {prod.QuantidadeTipoEstoque}");
                    }
                }

            }
            else if (IsSaida)
            {
                foreach (TipoDeItem prod in p.TipoDeItems)
                {
                    if (prod == TipoSelecionado)
                    {
                        prod.QuantidadeTipoEstoque -= ValorQuantidade;
                        MessageBox.Show($"Quantidade de {prod.NomeTipo} alterado para {prod.QuantidadeTipoEstoque}");
                    }
                }
            }

        }

        public bool EntradaEstoque(TipoDeItem ItemModificado)
        {
            if(ValorQuantidade == null)
            {
                return false;
            }
            else
            {
                ItemModificado.QuantidadeTipoEstoque += ValorQuantidade;
                return true;
            }
        }

    }
}

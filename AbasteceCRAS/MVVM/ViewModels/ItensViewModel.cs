using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class ItensViewModel: ViewModelBase
    {
        // --Botões --
        public ICommand RetornarParaHome { get; }
        public ICommand AdicionarItem {  get; }
        public ICommand AdicionarTipo { get; }


        //  --  Variáveis ---
        private string _nomeItem;
        public string NomeItem { 
            get => _nomeItem;
            set { _nomeItem = value; OnPropertyChanged(); 
            }
        }

        private Produto _itemSelecionado;
        public Produto ItemSelecionado
        {
            get => _itemSelecionado;
            set
            {
                _itemSelecionado = value;
                OnPropertyChanged(nameof(ItemSelecionado));
            }
        }

        private string _nomeDoTipo;
        public string NomeDoTipo
        {
            get => _nomeDoTipo;
            set
            {
                _nomeDoTipo = value;
                OnPropertyChanged();
            }
        }

        private bool _isPerecivel;
        public bool IsPerecivel
        {
            get => _isPerecivel;
            set
            {
                if (_isPerecivel != value)
                {
                    _isPerecivel = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _quantidadeTipoItem;
        public int QuantidadeTipoItem
        {
            get => _quantidadeTipoItem;
            set
            {
                _quantidadeTipoItem = value;
                OnPropertyChanged();
            }
        }

        //Construtor
        public ItensViewModel()
        {
            RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
            AdicionarItem = new RelayCommand(AdicionarItens);
            AdicionarTipo = new RelayCommand(AdicionarTipoItem);
            ItemSelecionado = null;
        }

        // -- Métodos --
        public void AdicionarItens(object parameter)
        {
            if (string.IsNullOrWhiteSpace(NomeItem))
            {
                MessageBox.Show("Digite um nome para o item.");
                return;
            }

            Produto p = new Produto(NomeItem);
            DadosService.Instance.ListaProduto.Add(p);

            NomeItem = string.Empty;
        }


        public void AdicionarTipoItem(object parameter) {
            var ItemAdicao = DadosService.Instance.ListaProduto.FirstOrDefault(n => n == ItemSelecionado);

            if (ItemAdicao != null)
            {
                //MessageBox.Show($"Produto: {ItemSelecionado.NomeItem}");

                if (ItemAdicao.AdicionarTipoItem(new TipoDeItem(NomeDoTipo, QuantidadeTipoItem)))
                {
                    MessageBox.Show("Item adicionado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Item não pôde ser adicionado!");
                }

            }
            else
            {
                MessageBox.Show("Selecione um produto");
            }

        }

    }
}

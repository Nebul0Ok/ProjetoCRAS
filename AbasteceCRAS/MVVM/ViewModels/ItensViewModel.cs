using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class ItensViewModel: ViewModelBase
    {
        // --Botões --
        public ICommand RetornarParaHome { get; }
        public ICommand AdicionarItem {  get; }
        public ICommand ExcluirItem { get; }
        public ICommand AdicionarTipo { get; }


        //  --  Variáveis ---
        private string _nomeItem;
        public string NomeItem { get => _nomeItem; set { _nomeItem = value; OnPropertyChanged(); } }

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


        public ItensViewModel()
        {
            RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
            AdicionarItem = new RelayCommand(AdicionarItens);
            ExcluirItem = new RelayCommand(RemoverItem);
            AdicionarTipo = new RelayCommand(AdicionarTipoItem);
        }

        // -- Métodos --
        public void AdicionarItens(object parameter)
        {
            Produto p = new Produto(NomeItem);
            DadosService.Instance.ListaProduto.Add(p);
        }

        public void RemoverItem(object parameter)
        {
            var produtoRemovido = DadosService.Instance.ListaProduto.FirstOrDefault(n => n == ItemSelecionado);

            if(produtoRemovido != null)
            {
                DadosService.Instance.ListaProduto.Remove(produtoRemovido);
            }
        }

        public void AdicionarTipoItem(object parameter) {
            if (ItemSelecionado == null || string.IsNullOrWhiteSpace(NomeDoTipo))
                return;

            var novoTipo = new TipoDeItem(NomeDoTipo, 0);
            ItemSelecionado.AdicionarTipoItem(novoTipo, SessionService.Instance.UsuarioLogado);

            OnPropertyChanged(nameof(ItemSelecionado));

        }

    }
}

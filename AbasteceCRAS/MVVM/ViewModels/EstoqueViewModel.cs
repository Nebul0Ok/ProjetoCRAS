using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class EstoqueViewModel: ViewModelBase
    {
        //Botões
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
            EntradaOperacaoVisibility = Visibility.Collapsed;
            SaidaOperacaoVisibility = Visibility.Collapsed;
            DepositoVisibility = Visibility.Collapsed;
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
                if (value) SwitchEntrada();

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
                if (value) SwitchSaida();
            }
        }

        private bool _isTrocaDeposito;
        public bool IsTrocaDeposito
        {
            get => _isTrocaDeposito;
            set
            {
                _isTrocaDeposito = value;
                OnPropertyChanged();
                if (value) SwitchDeposito();
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

        private Visibility _depositoVisibility;
        public Visibility DepositoVisibility
        {
            get => _depositoVisibility;
            set
            {
                _depositoVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _validadeVisibility;
        public Visibility ValidadeVisibility
        {
            get => _validadeVisibility;
            set
            {
                _validadeVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _entradaSaidaVisibility;
        public Visibility EntradaSaidaVisibility
        {
            get => _entradaSaidaVisibility;
            set
            {
                _entradaSaidaVisibility = value;
                OnPropertyChanged();
            }
        }


        private DateTime? _dataSelecionada;
        public DateTime? DataSelecionada
        {
            get => _dataSelecionada;
            set
            {
                _dataSelecionada = value;
                OnPropertyChanged();
            }
        }

        private Visibility _remessaVisibility;
        public Visibility RemessaVisibility
        {
            get => _remessaVisibility;
            set
            {
                _remessaVisibility = value;
                OnPropertyChanged();
            }
        }

        private Sala _salaSelecionada;
        public Sala SalaSelecionada
        {
            get => _salaSelecionada;
            set
            {
                _salaSelecionada = value;
                OnPropertyChanged();

                DepositoSelecionado = null;
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

                if (value.IsPerecivel)
                {
                    ValidadeVisibility = Visibility.Visible;
                }
                else
                {
                    ValidadeVisibility = Visibility.Collapsed;
                }

                TipoSelecionado = null;

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

                OnPropertyChanged(nameof(ListaRemessas));
            }
        }

        public ObservableCollection<Deposito> ListaDepositos
        {
            get
            {
                
                if (string.IsNullOrEmpty(LocalSelecionado))
                {
                    return DadosService.Instance.ListaDeposito;
                }
                var filtrados = DadosService.Instance.ListaDeposito
                    .Where(d => d.Localizacao == LocalSelecionado);
                return new ObservableCollection<Deposito>(filtrados);
            }
        }

        private Deposito _depositoSelecionado;
        public Deposito DepositoSelecionado
        {
            get => _depositoSelecionado;
            set
            {
                _depositoSelecionado = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<string> ListaLocais
        {
            get
            {
                var locais = DadosService.Instance.ListaDeposito
                    .Select(d => d.Localizacao)
                    .Where(l => !string.IsNullOrEmpty(l))
                    .Distinct();
                return new ObservableCollection<string>(locais);
            }
        }

        private string _localSelecionado;
        public string LocalSelecionado
        {
            get => _localSelecionado;
            set
            {
                _localSelecionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ListaDepositos)); 
                DepositoSelecionado = null;
            }
        }

        public ObservableCollection<Remessa> ListaRemessas
        {
            get
            {
                ObservableCollection<Remessa> remessas = new ObservableCollection<Remessa>();

                if (TipoSelecionado == null || TipoSelecionado.Remessas == null)
                {
                    return remessas;
                }

                foreach (Remessa r in TipoSelecionado.Remessas)
                {
                    remessas.Add(r);
                }

                return remessas;
            }
        }

        private Remessa _remessaSelecionada;
        public Remessa RemessaSelecionada
        {
            get => _remessaSelecionada;
            set
            {
                _remessaSelecionada = value;
                OnPropertyChanged();
            }
        }

        private Visibility _entradaOperacaoVisibility;
        public Visibility EntradaOperacaoVisibility
        {
            get => _entradaOperacaoVisibility;
            set
            {
                _entradaOperacaoVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _saidaOperacaoVisibility;
        public Visibility SaidaOperacaoVisibility
        {
            get => _saidaOperacaoVisibility;
            set
            {
                _saidaOperacaoVisibility = value;
                OnPropertyChanged();
            }
        }






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
            if (!IsEntrada && !IsSaida && !IsTrocaDeposito)
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
                        if (ItemSelecionado.IsPerecivel)
                        {
                            prod.AdicionarRemessa(new Remessa(ValorQuantidade, true, DataSelecionada, SalaSelecionada.Nome, SalaSelecionada.Nome));
                            DataSelecionada = null;
                        }
                        else
                        {
                            prod.AdicionarRemessa(new Remessa(ValorQuantidade, false, SalaSelecionada.Nome, SalaSelecionada.Nome));
                        }

                        OnPropertyChanged(nameof(ListaRemessas));

                        DadosService.Instance.SalvarHistorico($"Adicionado remessa de {ValorQuantidade} unidades ao estoque de {ItemSelecionado.NomeItem}: {prod.NomeTipo}");
                    }
                }

            }
            else if (IsSaida)
            {
                
                DataSelecionada = null;



                TipoDeItem? tipo = p.TipoDeItems.FirstOrDefault(o => o.NomeTipo == TipoSelecionado.NomeTipo);

                if (tipo == null) return;

                
                if (RemessaSelecionada == null)
                {
                    MessageBox.Show("Remessa não selecionada");
                    return;
                }

                if (ValorQuantidade > RemessaSelecionada.Quantidade)
                {
                    MessageBox.Show("Valor a reduzr maior do que há no estoque");
                    return;
                }

                if (RemessaSelecionada.Quantidade == 0)
                {
                    return;
                }

                Remessa remessaReduct = RemessaSelecionada;

                remessaReduct.Quantidade -= ValorQuantidade;

                DadosService.Instance.SalvarHistorico($"Reduzido {ValorQuantidade} do estoque de {ItemSelecionado.NomeItem}: {tipo.NomeTipo} cadastrado no dia {remessaReduct.DataRecebimento}");

            }
            else if (IsTrocaDeposito)
            {
                if (DepositoSelecionado == null)
                {
                    MessageBox.Show("Por favor, selecione o depósito de destino");
                    return;
                }
                foreach (TipoDeItem prod in p.TipoDeItems)
                {
                    if (prod == TipoSelecionado)
                    {
                        prod.DepositoAtual = DepositoSelecionado;
                        MessageBox.Show($"Depósito de {prod.NomeTipo} alterado para {DepositoSelecionado.Nome}");
                        DadosService.Instance.SalvarHistorico($"Local de {prod.NomeTipo} foi alterado para {DepositoSelecionado.Nome} em {LocalSelecionado}");
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

        public void SwitchEntrada()
        {
            if (EntradaOperacaoVisibility == Visibility.Visible) return;
            
            SaidaOperacaoVisibility = Visibility.Collapsed;
            DepositoVisibility = Visibility.Collapsed;

            EntradaOperacaoVisibility = Visibility.Visible;
            
        }

        public void SwitchSaida()
        {
            if (SaidaOperacaoVisibility == Visibility.Visible) return;

            EntradaOperacaoVisibility = Visibility.Collapsed;
            DepositoVisibility= Visibility.Collapsed;

            SaidaOperacaoVisibility = Visibility.Visible;
        }

        public void SwitchEntradaSaida()
        {
            if (EntradaSaidaVisibility == Visibility.Visible) return;

            DepositoVisibility = Visibility.Collapsed;
            EntradaSaidaVisibility = Visibility.Visible;

        }

        public void SwitchDeposito()
        {
            if (DepositoVisibility == Visibility.Visible) return;

            DepositoVisibility = Visibility.Collapsed;
            SaidaOperacaoVisibility = Visibility.Collapsed;

            DepositoVisibility = Visibility.Visible;
        }

    }
}

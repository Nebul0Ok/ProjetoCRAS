using AbasteceCRAS.MVVM.ViewModels;
using AbasteceCRAS.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;

namespace AbasteceCRAS.MVVM.Models;

public class TipoDeItem : ViewModelBase
{
    public int ID { get; set; }
    public int IDproduto { get; set; }
    public string NomeTipo { get; set; }
    public DateTime DataCadastroTipo { get; set; }

    private int _quantidadeTipoEstoque;
    public int QuantidadeTipoEstoque
    {
        get => _quantidadeTipoEstoque;
        set
        {
            _quantidadeTipoEstoque = value;
            OnPropertyChanged();
        }
    }
    private Deposito _depositoAtual;
    public Deposito DepositoAtual
    {
        get => _depositoAtual;
        set
        {
            _depositoAtual = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Remessa> Remessas { get; set; } = new ObservableCollection<Remessa>();

    public TipoDeItem(string NomeTipo, int QuantidadeTipoEstoque)
    {
        this.NomeTipo = NomeTipo;
        DataCadastroTipo = DateTime.Now;
        this.QuantidadeTipoEstoque = QuantidadeTipoEstoque;
        DepositoAtual = new Deposito("Nenhum", "Nenhum");
    }

    public TipoDeItem(string NomeTipo, int QuantidadeTipoEstoque, Deposito deposito)
    {
        this.NomeTipo = NomeTipo;
        DataCadastroTipo = DateTime.Now;
        this.QuantidadeTipoEstoque = QuantidadeTipoEstoque;
        DepositoAtual = DadosService.Instance.ListaDeposito.FirstOrDefault(p => p.Nome == deposito.Nome &&
                                                                                p.Localizacao == p.Localizacao);
    }


    public void AdicionarRemessa(Remessa r)
    {
        Remessas.Add(r);
    }

    public void ReduzirRemessa (Remessa r, int quant)
    {
        var remessa = Remessas.FirstOrDefault(o => o == r);

        remessa.Quantidade -= quant;
    }
}

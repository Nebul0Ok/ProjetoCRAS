using AbasteceCRAS.MVVM.ViewModels;
using AbasteceCRAS.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AbasteceCRAS.MVVM.Models;

public class TipoDeItem : ViewModelBase
{
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
    public Deposito DepositoAtual { get; set; }

    public TipoDeItem( string NomeTipo, int QuantidadeTipoEstoque, int QuantidadeTipoProduto, string Medida)
    {
        this.NomeTipo = NomeTipo;
        DataCadastroTipo = DateTime.Now;
        this.QuantidadeTipoEstoque = QuantidadeTipoEstoque;
        //this.QuantidadeTipoProduto = QuantidadeTipoProduto;
    }

    public TipoDeItem(string NomeTipo, int QuantidadeTipoEstoque)
    {
        this.NomeTipo = NomeTipo;
        DataCadastroTipo = DateTime.Now;
        this.QuantidadeTipoEstoque = QuantidadeTipoEstoque;
    }

    public TipoDeItem(string NomeTipo, int QuantidadeTipoEstoque, Deposito deposito)
    {
        this.NomeTipo = NomeTipo;
        DataCadastroTipo = DateTime.Now;
        this.QuantidadeTipoEstoque = QuantidadeTipoEstoque;
        DepositoAtual = DadosService.Instance.ListaDeposito.FirstOrDefault(p => p.Nome == deposito.Nome &&
                                                                                p.Localizacao == p.Localizacao);
    }

}

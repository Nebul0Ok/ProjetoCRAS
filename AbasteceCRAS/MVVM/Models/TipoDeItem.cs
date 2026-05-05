namespace AbasteceCRAS.MVVM.Models;

public class TipoDeItem
{
    public string NomeTipo { get; set; }
    public DateTime DataCadastroTipo { get; set; }
    public int QuantidadeTipoEstoque { get; set; }
    public int? QuantidadeTipoProduto { get; set; }
    public string? Medida { get; set; }
    public TipoDeItem( string NomeTipo, int QuantidadeTipoEstoque, int QuantidadeTipoProduto, string Medida)
    {
        this.NomeTipo = NomeTipo;
        DataCadastroTipo = DateTime.Now;
        this.QuantidadeTipoEstoque = QuantidadeTipoEstoque;
        //this.QuantidadeTipoProduto = QuantidadeTipoProduto;
        this.Medida = Medida;
    }

    public TipoDeItem(string NomeTipo, int QuantidadeTipoEstoque)
    {
        this.NomeTipo = NomeTipo;
        DataCadastroTipo = DateTime.Now;
        this.QuantidadeTipoEstoque = QuantidadeTipoEstoque;
    }

}

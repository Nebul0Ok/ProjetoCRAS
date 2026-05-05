namespace AbasteceCRAS.MVVM.Models;

public class Produto
{
    public string NomeItem { get; set; }
    public DateTime DataCadastroItem { get; set; }
    public List<TipoDeItem> TipoDeItems { get; set; }
    public int QuantidadeDeTipos {  get; set; }

    public Produto(string NomeItem)
    {
        this.NomeItem = NomeItem;
        DataCadastroItem = DateTime.Now;
        TipoDeItems = new List<TipoDeItem>();
        QuantidadeDeTipos = TipoDeItems.Count;
    }

    // Adiciona um tipo ao item
    public bool AdicionarTipoItem(TipoDeItem novoTipo, Usuario user)
    {
        if (novoTipo == null)
            return false;

        TipoDeItems.Add(novoTipo);
        QuantidadeDeTipos = TipoDeItems.Count;

        //Historico.Registrar(user.Nome, $"Tipo '{novoTipo.NomeTipo}' adicionado ao item '{NomeItem}'");

        return true;
    }

    // Remove um tipo do item
    public bool RemoveTipoItem(TipoDeItem itemRemovido, Usuario user)
    {
        if (itemRemovido == null)
            return false;

        var tipoExistente = TipoDeItems.FirstOrDefault(t => t.NomeTipo == itemRemovido.NomeTipo);

        if (tipoExistente == null)
            return false;

        TipoDeItems.Remove(tipoExistente);

        QuantidadeDeTipos = TipoDeItems.Count;

        //Historico.Registrar(user.Nome, $"Tipo '{tipoExistente.NomeTipo}' removido do item '{NomeItem}'");

        return true;
    }

    // Faz Update de tipo de item
    public bool AtualizarTipoItem(TipoDeItem tipoAtualizado, Usuario user)
    {
        if (tipoAtualizado == null)
            return false;

        var tipoExistente = TipoDeItems.FirstOrDefault(t => t.NomeTipo == tipoAtualizado.NomeTipo);

        if (tipoExistente == null)
            return false;

        tipoExistente.NomeTipo = tipoAtualizado.NomeTipo;
        tipoExistente.QuantidadeTipoEstoque = tipoAtualizado.QuantidadeTipoEstoque;
        tipoExistente.QuantidadeTipoProduto = tipoAtualizado.QuantidadeTipoProduto;
        tipoExistente.Medida = tipoAtualizado.Medida;

        //Historico.Registrar(user.NomeUsuario, $"Tipo '{tipoExistente.NomeTipo}' atualizado no item '{NomeItem}'");

        return true;
    }
}

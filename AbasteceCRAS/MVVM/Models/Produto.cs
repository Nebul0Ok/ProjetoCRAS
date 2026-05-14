using AbasteceCRAS.Core;
using AbasteceCRAS.Services;
using System.Collections.ObjectModel;

namespace AbasteceCRAS.MVVM.Models;

public class Produto: OnPropertyChangedHandler
{
    public string NomeItem { get; set; }
    public DateTime DataCadastroItem { get; set; }
    public ObservableCollection<TipoDeItem> TipoDeItems { get; set; }

    private int _quantidadeDeTipos;
    public int QuantidadeDeTipos {
        get => _quantidadeDeTipos;
        set
        {
            _quantidadeDeTipos = value;
            OnPropertyChanged();
        }
    }

    private bool _expandido;
    public bool Expandido
    {
        get => _expandido;
        set
        {
            _expandido = value;
            OnPropertyChanged();
        }
    }

    public Produto(string NomeItem)
    {
        this.NomeItem = NomeItem;
        DataCadastroItem = DateTime.Now;
        TipoDeItems = new ObservableCollection<TipoDeItem>();
        QuantidadeDeTipos = TipoDeItems.Count;
        
    }

    public Produto(string NomeItem, int Quantidade)
    {
        this.NomeItem = NomeItem;
        DataCadastroItem = DateTime.Now;
        TipoDeItems = new ObservableCollection<TipoDeItem>();
        QuantidadeDeTipos = Quantidade;

    }

    public Produto(string NomeItem, int Quantidade, Deposito deposito)
    {
        this.NomeItem = NomeItem;
        DataCadastroItem = DateTime.Now;
        TipoDeItems = new ObservableCollection<TipoDeItem>();
        QuantidadeDeTipos = Quantidade;
        
    }



    // Adiciona um tipo ao item
    public bool AdicionarTipoItem(TipoDeItem novoTipo)
    {
        if (novoTipo == null)
            return false;

        TipoDeItems.Add(novoTipo);
        QuantidadeDeTipos = TipoDeItems.Count;

        DadosService.Instance.ListaHistorico.Add(new Historico($"Tipo '{novoTipo.NomeTipo}' adicionado", SessionService.Instance.UsuarioLogado.Nome));

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
        //Historico.Registrar(user.NomeUsuario, $"Tipo '{tipoExistente.NomeTipo}' atualizado no item '{NomeItem}'");

        return true;
    }
}

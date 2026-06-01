using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.MVVM.ViewModels;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Reflection;

namespace AbasteceCRAS.Services;
public class DadosService
{
    private DadosService()
    {
    }

    private static DadosService _instance;
    public static DadosService Instance => _instance ??= new DadosService();


    //Listas
    public ObservableCollection<Produto> ListaProduto { get; set; } = new ObservableCollection<Produto>();
    public ObservableCollection<Historico> ListaHistorico { get; set; } = new ObservableCollection<Historico>();
    public ObservableCollection<Deposito> ListaDeposito { get; set; } = new ObservableCollection<Deposito>();
    public ObservableCollection<Sala> ListaSala { get; set; } = new ObservableCollection<Sala>();

    private Stack<Notificacao> _notificacoes = new Stack<Notificacao>();
    public Stack<Notificacao> Notificacoes = new Stack<Notificacao>();
                     //ID   Produto
    public Dictionary<int, Produto> ItemLista { get; set; } = new Dictionary<int, Produto>();
    public Dictionary<int, TipoDeItem> TipoDeItemLista { get; set; } = new Dictionary<int, TipoDeItem>();
    public Dictionary<int, Remessa> RemessaLista { get; set; } = new Dictionary<int, Remessa>();
    public Dictionary<int, Sala> SalaLista { get; set; } = new Dictionary<int, Sala>();
    public Dictionary<int, Deposito> DepositoLista { get; set; } = new Dictionary<int, Deposito>();



    //Funções

        //Historico
    public void SalvarHistorico(string ocorrencia)
    {
        DadosService.Instance.ListaHistorico.Add(new Historico(ocorrencia, SessionService.Instance.UsuarioLogado.Nome));
    }

    public void SalvarHistoricoSistema(string ocorrencia)
    {
        DadosService.Instance.ListaHistorico.Add(new Historico(ocorrencia, "Sistema"));
    }

    //Notificações
    public void AdicionarNotificacao(string header, string body)
    {
        Notificacoes.Push(new Notificacao(header, body));

        if (MainViewModel.Instance !=null)
        {
            MainViewModel.Instance.AtualizarNotificacoes();
        }
    }

    public void RemoverNotificacao()
    {
        Notificacoes.Pop();
    }

    public void LimparNotificacoes()
    {
        Notificacoes.Clear();
    }

        //Adicionar
    public bool AdicionarItem(Produto p)
    {

        if (ItemLista.ContainsValue(p)) return false;

        int id = ItemLista.Count + 1;
        p.ID = id;
        ItemLista.Add(id, p);
        ListaProduto.Add(p);

        return true;
    }

    public bool AdicionarTipoDeItem(TipoDeItem p)
    {
        if (TipoDeItemLista.ContainsValue(p)) return false;

        int id = TipoDeItemLista.Count + 1;
        p.ID = id;
        TipoDeItemLista.Add(id, p);

        return true;
    }
    public bool AdicionarRemessa(Remessa p)
    {
        if (RemessaLista.ContainsValue(p)) return false;

        int id = RemessaLista.Count + 1;
        p.ID = id;
        RemessaLista.Add(id, p);

        return true;
    }

    public bool AdicionarSala(Sala p)
    {
        if (SalaLista.ContainsValue(p)) return false;

        int id = SalaLista.Count + 1;
        p.ID = id;
        SalaLista.Add(id, p);
        ListaSala.Add(p);

        return true;
    }

    //public void AdicionarDeposito(Deposito p)
    //{
    //    if (DepositoLista.ContainsValue(p)) return;

    //    int id = DepositoLista.Count + 1;
    //    p.ID = id;
    //    DepositoLista.Add(id, p);

    //    return;
    //}

    public void AdicionarDepositoNaSala(Sala s, Deposito d)
    {
        if (s.Depositos.FirstOrDefault(o => o.Nome.Equals(d.Nome)) != null) return;
        else
        {
            d.ID = s.Depositos.Count + 1;
            s.Depositos.Add(d);
        }
    }
}
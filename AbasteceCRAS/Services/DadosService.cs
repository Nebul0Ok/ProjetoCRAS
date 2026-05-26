using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.MVVM.ViewModels;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;

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

    private Stack<Notificacao> _notificacoes = new Stack<Notificacao>();
    public Stack<Notificacao> Notificacoes = new Stack<Notificacao>();




    //Funções

        //Historico
    public void SalvarHistorico(string ocorrencia)
    {
        DadosService.Instance.ListaHistorico.Add(new Historico(ocorrencia, SessionService.Instance.UsuarioLogado.Nome));
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

}
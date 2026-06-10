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
        // Mock de salas
        Sala coordenacao = new Sala("Coordenação");
        Sala cozinha = new Sala("Cozinha");
        Sala almoxarifado = new Sala("Almoxarifado");
        Sala salaEsquerda = new Sala("Sala Esquerda");
        AdicionarSala(coordenacao);
        AdicionarSala(cozinha);
        AdicionarSala(almoxarifado);
        AdicionarSala(salaEsquerda);

        // Mock de depósitos
        Deposito armarioCinza = new Deposito("Armario Cinza", "Parede do lado da porta");
        armarioCinza.IdSala = 1;
        AdicionarDepositoNaSala(coordenacao, armarioCinza);
        ListaDeposito.Add(armarioCinza);
        DepositoLista.Add(DepositoLista.Count + 1, armarioCinza);

        Deposito prateleiraPreta = new Deposito("Prateleira Preta", "Entre as mesas");
        prateleiraPreta.IdSala = 1;
        AdicionarDepositoNaSala(coordenacao, prateleiraPreta);
        ListaDeposito.Add(prateleiraPreta);
        DepositoLista.Add(DepositoLista.Count + 1, prateleiraPreta);

        Deposito armarioSuspenso = new Deposito("Armario Suspenso", "");
        armarioSuspenso.IdSala = 2;
        AdicionarDepositoNaSala(cozinha, armarioSuspenso);
        ListaDeposito.Add(armarioSuspenso);
        DepositoLista.Add(DepositoLista.Count + 1, armarioSuspenso);

        Deposito geladeira = new Deposito("Geladeira", "");
        geladeira.IdSala = 2;
        AdicionarDepositoNaSala(cozinha, geladeira);
        ListaDeposito.Add(geladeira);
        DepositoLista.Add(DepositoLista.Count + 1, geladeira);

        Deposito arquivoCinza = new Deposito("Arquivo Cinza", "");
        arquivoCinza.IdSala = 3;
        AdicionarDepositoNaSala(almoxarifado, arquivoCinza);
        ListaDeposito.Add(arquivoCinza);
        DepositoLista.Add(DepositoLista.Count + 1, arquivoCinza);

        Deposito armarioDeMadeira1 = new Deposito("Armario de madeira", "");
        armarioDeMadeira1.IdSala = 3;
        AdicionarDepositoNaSala(almoxarifado, armarioDeMadeira1);
        ListaDeposito.Add(armarioDeMadeira1);
        DepositoLista.Add(DepositoLista.Count + 1, armarioDeMadeira1);

        Deposito armarioDeMadeira2 = new Deposito("Armario de madeira", "");
        armarioDeMadeira2.IdSala = 4;
        AdicionarDepositoNaSala(salaEsquerda, armarioDeMadeira2);
        ListaDeposito.Add(armarioDeMadeira2);
        DepositoLista.Add(DepositoLista.Count + 1, armarioDeMadeira2);

        // Mock de Produtos
        Produto arroz = new Produto("Arroz", true);
        Produto detergente = new Produto("Detergente", false);

        AdicionarItem(arroz);
        AdicionarItem(detergente);

        // Mock de tipos 
        TipoDeItem arroz5kg = new TipoDeItem("5 kg");
        arroz5kg.IDproduto = arroz.ID;
        arroz.TipoDeItems.Add(arroz5kg);
        arroz.QuantidadeDeTipos = arroz.TipoDeItems.Count;
        AdicionarTipoDeItem(arroz5kg);

        TipoDeItem arroz1kg = new TipoDeItem("1 kg");
        arroz1kg.IDproduto = arroz.ID;
        arroz.TipoDeItems.Add(arroz1kg);
        arroz.QuantidadeDeTipos = arroz.TipoDeItems.Count;
        AdicionarTipoDeItem(arroz1kg);

        TipoDeItem detCoco = new TipoDeItem("Coco");
        detCoco.IDproduto = detergente.ID;
        detergente.TipoDeItems.Add(detCoco);
        detergente.QuantidadeDeTipos = detergente.TipoDeItems.Count;
        AdicionarTipoDeItem(detCoco);

        // Mock de Remessas
        Remessa loteArroz = new Remessa(
            Quantidade: 30,
            IsPerecivel: true,
            DataValidade: DateTime.Today.AddMonths(6),
            Local: armarioSuspenso.Nome, // Local/Depósito
            Sala: cozinha.Nome           // Sala
        );
        arroz5kg.AdicionarRemessa(loteArroz);
        AdicionarRemessa(loteArroz);

        Remessa loteDetergente = new Remessa(
            Quantidade: 15,
            IsPerecivel: false,
            Local: armarioDeMadeira1.Nome, // Local/Depósito
            Sala: almoxarifado.Nome         // Sala
        );
        detCoco.AdicionarRemessa(loteDetergente);
        AdicionarRemessa(loteDetergente);

    }

    private static DadosService _instance;
    public static DadosService Instance => _instance ??= new DadosService();


    //Listas
    public ObservableCollection<Produto> ListaProduto { get; set; } = new ObservableCollection<Produto>();
    public ObservableCollection<Historico> ListaHistorico { get; set; } = new ObservableCollection<Historico>();
    public ObservableCollection<Deposito> ListaDeposito { get; set; } = new ObservableCollection<Deposito>();
    public ObservableCollection<Sala> ListaSala { get; set; } = new ObservableCollection<Sala>();
    public ObservableCollection<Notificacao> NotificacoesAtuais { get; set; } = new ObservableCollection<Notificacao>();

    public Stack<Notificacao> Notificacoes = new Stack<Notificacao>();
    
                     //ID   Valor
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

    public void AdicionarNotificacaoQueue()
    {
        if (Notificacoes.Count == 0) return;
        else
        {
            NotificacoesAtuais.Insert(0, Notificacoes.Pop());
        }
    }

    public void VerificarValidades()
    {
        foreach (var produto in ListaProduto)
        {
            foreach (var tipo in produto.TipoDeItems)
            {
                foreach (var remessa in tipo.Remessas)
                {
                    // Ignora se o produto não for perecível ou não tiver validade
                    if (remessa.DataValidade == null) continue;
                    TimeSpan diferenca = remessa.DataValidade.Value - DateTime.Now;
                    if (diferenca.TotalDays <= 0)
                    {
                        // Produto já venceu
                        AdicionarNotificacao(
                            "Produto Estragado",
                            $"O lote de '{produto.NomeItem} ({tipo.NomeTipo})' na sala '{remessa.Sala}' estragou há {Math.Abs((int)diferenca.TotalDays)} dias."
                        );
                    }
                    else if (diferenca.TotalDays <= 7)
                    {
                        // Produto vence em até 7 dias
                        AdicionarNotificacao(
                            "Produto Perto de Vencer",
                            $"O lote de '{produto.NomeItem} ({tipo.NomeTipo})' na sala '{remessa.Sala}' irá estragar em {(int)diferenca.TotalDays} dias."
                        );
                    }
                }
            }
        }
    }

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
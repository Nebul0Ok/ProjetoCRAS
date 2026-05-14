using AbasteceCRAS.MVVM.Models;
using System.Collections.ObjectModel;

namespace AbasteceCRAS.Services;
public class DadosService
{
    private static DadosService _instance;
    public static DadosService Instance => _instance ??= new DadosService();

    public ObservableCollection<Produto> ListaProduto { get; set; } = new ObservableCollection<Produto>();
    public ObservableCollection<Historico> ListaHistorico { get; set; } = new ObservableCollection<Historico>();
    public ObservableCollection<Deposito> ListaDeposito { get; set; } = new ObservableCollection<Deposito>();
    public Dictionary<String, String> UsuariosCadastrados = new Dictionary<String, String>();


    private DadosService()
    {
    }

    public void CadastrarUsuario(string email, string senha)
    {
        
    }

    
}
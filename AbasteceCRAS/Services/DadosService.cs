using AbasteceCRAS.MVVM.Models;
using System.Collections.ObjectModel;

namespace AbasteceCRAS.Services;
public class DadosService
{
    private static DadosService _instance;
    public static DadosService Instance => _instance ??= new DadosService();

    public ObservableCollection<Produto> ListaProduto { get; set; }
    public ObservableCollection<Historico> ListaHistorico { get; set; }
    public ObservableCollection<Deposito> ListaDeposito { get; set; }

    private DadosService()
    {
    }
}

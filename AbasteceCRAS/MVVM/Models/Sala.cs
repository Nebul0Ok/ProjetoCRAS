
using System.Collections.ObjectModel;

namespace AbasteceCRAS.MVVM.Models;

public class Sala
{
    public int ID { get; set; }
    public string Nome { get; set; }

    public ObservableCollection<Deposito> Depositos { get; set; }

    public Sala(string Nome)
    {
        this.Nome = Nome;
        Depositos = new ObservableCollection<Deposito>();
    }
}

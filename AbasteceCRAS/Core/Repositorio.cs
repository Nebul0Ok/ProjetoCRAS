using System.Collections.ObjectModel;

namespace AbasteceCRAS.Core;

public class Repositorio<T>
{
    public ObservableCollection<T> Lista { get; set; }
    public Dictionary<int, T> Dicionario { get; set; }
    private int ProximoItemLista = 1;

    public Repositorio()
    {
        Lista = new ObservableCollection<T>();
        Dicionario = new Dictionary<int, T>();
    }

    public void AdicionarItem(T item)
    {
        if (Dicionario.ContainsValue(item)) return;

        Dicionario.Add(ProximoItemLista, item);
        Lista.Add(item);
        ProximoItemLista++;
    }

}

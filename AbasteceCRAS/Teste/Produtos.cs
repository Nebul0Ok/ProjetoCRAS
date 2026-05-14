using AbasteceCRAS.MVVM.Models;
using System.Collections.ObjectModel;

namespace AbasteceCRAS.Teste;

public class Produtos
{
    public static List<Produto> prod = new List<Produto>
    {
        new Produto("Arroz", 3)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Branco 1KG", 50, Armazens.ArmazemMock[0]),
                new TipoDeItem("Branco 5KG", 20, Armazens.ArmazemMock[1]),
                new TipoDeItem("Integral 1KG", 15, Armazens.ArmazemMock[2])
            }
        },

        new Produto("Feijão", 3)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Carioca 1KG", 40, Armazens.ArmazemMock[4]),
                new TipoDeItem("Preto 1KG", 35, Armazens.ArmazemMock[1]),
                new TipoDeItem("Fradinho 1KG", 12, Armazens.ArmazemMock[3])
            }
        },

        new Produto("Macarrão", 3)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Espaguete 500G", 60, Armazens.ArmazemMock[4]),
                new TipoDeItem("Parafuso 500G", 45, Armazens.ArmazemMock[2]),
                new TipoDeItem("Penne 500G", 25, Armazens.ArmazemMock[3])
            }
        },

        new Produto("Açúcar", 2)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Cristal 1KG", 80, Armazens.ArmazemMock[1]),
                new TipoDeItem("Refinado 1KG", 35, Armazens.ArmazemMock[0])
            }
        },

        new Produto("Sal", 2)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Refinado 1KG", 70, Armazens.ArmazemMock[1]),
                new TipoDeItem("Grosso 1KG", 18, Armazens.ArmazemMock[1])
            }
        },

        new Produto("Óleo", 2)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Soja 900ML", 90, Armazens.ArmazemMock[0]),
                new TipoDeItem("Canola 900ML", 22, Armazens.ArmazemMock[0])
            }
        },

        new Produto("Leite", 3)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Integral 1L", 100, Armazens.ArmazemMock[3]),
                new TipoDeItem("Desnatado 1L", 40, Armazens.ArmazemMock[3]),
                new TipoDeItem("Sem Lactose 1L", 15, Armazens.ArmazemMock[4])
            }
        },

        new Produto("Café", 2)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Tradicional 500G", 65, Armazens.ArmazemMock[1]),
                new TipoDeItem("Extra Forte 500G", 30, Armazens.ArmazemMock[2])
            }
        }
    };
}
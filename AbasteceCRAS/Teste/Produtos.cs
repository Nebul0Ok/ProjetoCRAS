using AbasteceCRAS.MVVM.Models;
using System.Collections.ObjectModel;

namespace AbasteceCRAS.Teste;

public class Produtos
{
    public static List<Produto> prod = new List<Produto>
    {
        new Produto("Arroz", 3, true)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Branco 1KG", Armazens.ArmazemMock[0]),
                new TipoDeItem("Branco 5KG", Armazens.ArmazemMock[1]),
                new TipoDeItem("Integral 1KG", Armazens.ArmazemMock[2])
            }
        },

        new Produto("Feijão", 3, true)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Carioca 1KG",  Armazens.ArmazemMock[4]),
                new TipoDeItem("Preto 1KG",  Armazens.ArmazemMock[1]),
                new TipoDeItem("Fradinho 1KG",  Armazens.ArmazemMock[3])
            }
        },

        new Produto("Macarrão", 3, true)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Espaguete 500G", Armazens.ArmazemMock[4]),
                new TipoDeItem("Parafuso 500G",  Armazens.ArmazemMock[2]),
                new TipoDeItem("Penne 500G",  Armazens.ArmazemMock[3])
            }
        },

        new Produto("Açúcar", 2, true)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Cristal 1KG",  Armazens.ArmazemMock[1]),
                new TipoDeItem("Refinado 1KG",  Armazens.ArmazemMock[0])
            }
        },

        new Produto("Sal", 2, false)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Refinado 1KG",  Armazens.ArmazemMock[1]),
                new TipoDeItem("Grosso 1KG",  Armazens.ArmazemMock[1])
            }
        },

        new Produto("Óleo", 2, true)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Soja 900ML",  Armazens.ArmazemMock[0]),
                new TipoDeItem("Canola 900ML",  Armazens.ArmazemMock[0])
            }
        },

        new Produto("Leite", 3, true)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Integral 1L",  Armazens.ArmazemMock[3]),
                new TipoDeItem("Desnatado 1L",  Armazens.ArmazemMock[3]),
                new TipoDeItem("Sem Lactose 1L",  Armazens.ArmazemMock[4])
            }
        },

        new Produto("Café", 2, true)
        {
            TipoDeItems = new ObservableCollection<TipoDeItem>
            {
                new TipoDeItem("Tradicional 500G",  Armazens.ArmazemMock[1]),
                new TipoDeItem("Extra Forte 500G",  Armazens.ArmazemMock[2])
            }
        }
    };
}
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
            new TipoDeItem("Branco 1KG", 50),
            new TipoDeItem("Branco 5KG", 20),
            new TipoDeItem("Integral 1KG", 15)
        }
    },

    new Produto("Feijão", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Carioca 1KG", 40),
            new TipoDeItem("Preto 1KG", 35),
            new TipoDeItem("Fradinho 1KG", 12)
        }
    },

    new Produto("Macarrão", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Espaguete 500G", 60),
            new TipoDeItem("Parafuso 500G", 45),
            new TipoDeItem("Penne 500G", 25)
        }
    },

    new Produto("Açúcar", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Cristal 1KG", 80),
            new TipoDeItem("Refinado 1KG", 35)
        }
    },

    new Produto("Sal", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Refinado 1KG", 70),
            new TipoDeItem("Grosso 1KG", 18)
        }
    },

    new Produto("Óleo", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Soja 900ML", 90),
            new TipoDeItem("Canola 900ML", 22)
        }
    },

    new Produto("Leite", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Integral 1L", 100),
            new TipoDeItem("Desnatado 1L", 40),
            new TipoDeItem("Sem Lactose 1L", 15)
        }
    },

    new Produto("Café", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Tradicional 500G", 65),
            new TipoDeItem("Extra Forte 500G", 30)
        }
    },

    new Produto("Farinha", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Trigo 1KG", 55),
            new TipoDeItem("Mandioca 1KG", 28),
            new TipoDeItem("Milho 1KG", 21)
        }
    },

    new Produto("Biscoito", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Cream Cracker", 44),
            new TipoDeItem("Maisena", 31),
            new TipoDeItem("Recheado Chocolate", 52)
        }
    },

    new Produto("Sabonete", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Neutro", 70),
            new TipoDeItem("Lavanda", 32),
            new TipoDeItem("Erva Doce", 26)
        }
    },

    new Produto("Shampoo", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Anticaspa 400ML", 18),
            new TipoDeItem("Hidratação 350ML", 29),
            new TipoDeItem("Infantil 200ML", 16)
        }
    },

    new Produto("Detergente", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Neutro 500ML", 58),
            new TipoDeItem("Limão 500ML", 46),
            new TipoDeItem("Coco 500ML", 20)
        }
    },

    new Produto("Sabão em Pó", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("800G", 37),
            new TipoDeItem("1.6KG", 18)
        }
    },

    new Produto("Papel Higiênico", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("4 Rolos", 80),
            new TipoDeItem("12 Rolos", 42)
        }
    },

    new Produto("Creme Dental", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Menta 90G", 47),
            new TipoDeItem("Branqueador 90G", 25)
        }
    },

    new Produto("Escova de Dente", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Macia", 60),
            new TipoDeItem("Média", 34),
            new TipoDeItem("Infantil", 19)
        }
    },

    new Produto("Suco", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Laranja 1L", 27),
            new TipoDeItem("Uva 1L", 19),
            new TipoDeItem("Maracujá 1L", 16)
        }
    },

    new Produto("Refrigerante", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Cola 2L", 40),
            new TipoDeItem("Guaraná 2L", 28),
            new TipoDeItem("Laranja 2L", 17)
        }
    },

    new Produto("Achocolatado", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("400G", 22),
            new TipoDeItem("800G", 11)
        }
    },

    new Produto("Margarina", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Com Sal 500G", 33),
            new TipoDeItem("Sem Sal 500G", 14)
        }
    },

    new Produto("Queijo", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Mussarela 500G", 24),
            new TipoDeItem("Prato 500G", 16),
            new TipoDeItem("Parmesão 200G", 9)
        }
    },

    new Produto("Presunto", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Fatiado 500G", 18),
            new TipoDeItem("Defumado 500G", 10)
        }
    },

    new Produto("Fralda", 4)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("P", 25),
            new TipoDeItem("M", 40),
            new TipoDeItem("G", 36),
            new TipoDeItem("XG", 19)
        }
    },

    new Produto("Absorvente", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Com Abas", 54),
            new TipoDeItem("Sem Abas", 23),
            new TipoDeItem("Noturno", 15)
        }
    },

    new Produto("Água Sanitária", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("1L", 48),
            new TipoDeItem("2L", 21)
        }
    },

    new Produto("Desinfetante", 3)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Lavanda 2L", 39),
            new TipoDeItem("Pinho 2L", 17),
            new TipoDeItem("Citrus 2L", 14)
        }
    },

    new Produto("Esponja", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Dupla Face", 70),
            new TipoDeItem("Lã de Aço", 33)
        }
    },

    new Produto("Milho", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Verde Lata", 31),
            new TipoDeItem("Pipoca 500G", 28)
        }
    },

    new Produto("Ervilha", 2)
    {
        TipoDeItems = new ObservableCollection<TipoDeItem>
        {
            new TipoDeItem("Lata 200G", 24),
            new TipoDeItem("Seca 500G", 12)
        }
    }
};
}

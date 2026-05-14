using AbasteceCRAS.MVVM.Models;

namespace AbasteceCRAS.Teste;

public class Armazens
{
    public static List<Deposito> ArmazemMock = new List<Deposito>
    {
        new Deposito("Armario cinza esquerdo","Diretoria"),
        new Deposito("Armario cinza direito","Diretoria"),
        new Deposito("Estante preta 1","Diretoria"),
        new Deposito("Estante preta 2", "Diretoria"),
        new Deposito("Estante preta 3","Diretoria"),
        new Deposito("Armario","Cozinha"),
        new Deposito("Geladeira","Cozinha"),
        new Deposito("Armario de madeira 1","Sala da direita"),
        new Deposito("Armario de madeira 2","Sala da direita"),
        new Deposito("Armario de madeira","Sala de cima"),
        new Deposito("Arquivo 1","Sala de cima"),
        new Deposito("Arquivo 2","Sala de cima")
    };
}

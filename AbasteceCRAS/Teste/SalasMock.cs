using AbasteceCRAS.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbasteceCRAS.Teste;

public class SalasMock
{
    public static ObservableCollection<Sala> salasMocks = new ObservableCollection<Sala>()
    {
        new Sala("Sala da Diretoria")
        {
            ID = 1
        },

        new Sala("Sala Administrativa")
        {
            ID = 2
        },

        new Sala("Almoxarifado")
        {
            ID = 3
        },

        new Sala("Sala Superior")
        {
            ID = 4
        },

        new Sala("Cozinha")
        {
            ID = 5
        }
    };
}

public class DepositosMock
{
    public static ObservableCollection<Deposito> depositosMock = new ObservableCollection<Deposito>()
    {
        new Deposito("Depósito Principal", "Ao lado da porta de entrada")
    {
        ID = 1,
        IdSala = 1
    },

    new Deposito("Arquivo Administrativo", "Armário no canto esquerdo")
    {
        ID = 2,
        IdSala = 1
    },

    new Deposito("Estoque de Cestas Básicas", "Prateleiras do fundo")
    {
        ID = 3,
        IdSala = 2
    },

    new Deposito("Material de Limpeza", "Armário próximo à janela")
    {
        ID = 4,
        IdSala = 3
    },

    new Deposito("Equipamentos", "Estante central")
    {
        ID = 5,
        IdSala = 3
    },

    new Deposito("Documentação", "Arquivo metálico à direita")
    {
        ID = 6,
        IdSala = 4
    },

    new Deposito("Armario", "Suspenso")
    {
        ID = 7,
        IdSala = 5
    },

    new Deposito("Geladeira", "Metálica")
    {
        ID = 8,
        IdSala = 5
    }

    };
}

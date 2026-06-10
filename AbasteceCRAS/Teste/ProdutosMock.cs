using AbasteceCRAS.MVVM.Models;
using System;
using System.Collections.ObjectModel;
using static AbasteceCRAS.Teste.SalasMock;
using static AbasteceCRAS.Teste.DepositosMock;

namespace AbasteceCRAS.Teste;

public class ProdutosMock
{
    public static ObservableCollection<Produto> produtosMock = new()
    {
        new Produto("Arroz 5kg", true)
        {
            ID = 1,
            TipoDeItems =
            {
                new TipoDeItem("Tipo 1")
                {
                    ID = 1,
                    IDproduto = 1,
                    DepositoAtual = depositosMock[2],
                    Remessas =
                    {
                        new Remessa(60, true, DateTime.Now.AddMonths(6),
                            depositosMock[2].Nome, salasMocks[1].Nome)
                    }
                }
            }
        },

        new Produto("Feijão Carioca", true)
        {
            ID = 2,
            TipoDeItems =
            {
                new TipoDeItem("Tipo 1")
                {
                    ID = 2,
                    IDproduto = 2,
                    DepositoAtual = depositosMock[2],
                    Remessas =
                    {
                        new Remessa(40, true, DateTime.Now.AddMonths(5),
                            depositosMock[2].Nome, salasMocks[1].Nome)
                    }
                }
            }
        },

        new Produto("Macarrão Espaguete", true)
        {
            ID = 3,
            TipoDeItems =
            {
                new TipoDeItem("500g")
                {
                    ID = 3,
                    IDproduto = 3,
                    DepositoAtual = depositosMock[2],
                    Remessas =
                    {
                        new Remessa(80, true, DateTime.Now.AddMonths(10),
                            depositosMock[2].Nome, salasMocks[1].Nome)
                    }
                }
            }
        },

        new Produto("Leite Integral", true)
        {
            ID = 4,
            TipoDeItems =
            {
                new TipoDeItem("1L")
                {
                    ID = 4,
                    IDproduto = 4,
                    DepositoAtual = depositosMock[7],
                    Remessas =
                    {
                        new Remessa(24, true, DateTime.Now.AddDays(12),
                            depositosMock[7].Nome, salasMocks[4].Nome)
                    }
                }
            }
        },

        new Produto("Óleo de Soja", true)
        {
            ID = 5,
            TipoDeItems =
            {
                new TipoDeItem("900ml")
                {
                    ID = 5,
                    IDproduto = 5,
                    DepositoAtual = depositosMock[7],
                    Remessas =
                    {
                        new Remessa(50, true, DateTime.Now.AddMonths(12),
                            depositosMock[7].Nome, salasMocks[4].Nome)
                    }
                }
            }
        },

        new Produto("Açúcar 1kg", true)
        {
            ID = 6,
            TipoDeItems =
            {
                new TipoDeItem("Cristal")
                {
                    ID = 6,
                    IDproduto = 6,
                    DepositoAtual = depositosMock[1],
                    Remessas =
                    {
                        new Remessa(70, true, DateTime.Now.AddMonths(8),
                            depositosMock[1].Nome, salasMocks[0].Nome)
                    }
                }
            }
        },

        new Produto("Café 500g", true)
        {
            ID = 7,
            TipoDeItems =
            {
                new TipoDeItem("Torrado e Moído")
                {
                    ID = 7,
                    IDproduto = 7,
                    DepositoAtual = depositosMock[1],
                    Remessas =
                    {
                        new Remessa(35, true, DateTime.Now.AddMonths(6),
                            depositosMock[1].Nome, salasMocks[0].Nome)
                    }
                }
            }
        },

        new Produto("Detergente", false)
        {
            ID = 8,
            TipoDeItems =
            {
                new TipoDeItem("500ml")
                {
                    ID = 8,
                    IDproduto = 8,
                    DepositoAtual = depositosMock[3],
                    Remessas =
                    {
                        new Remessa(60, false,
                            depositosMock[3].Nome, salasMocks[2].Nome)
                    }
                }
            }
        },

        new Produto("Sabão em Pó", false)
        {
            ID = 9,
            TipoDeItems =
            {
                new TipoDeItem("1kg")
                {
                    ID = 9,
                    IDproduto = 9,
                    DepositoAtual = depositosMock[3],
                    Remessas =
                    {
                        new Remessa(45, false,
                            depositosMock[3].Nome, salasMocks[2].Nome)
                    }
                }
            }
        },

        new Produto("Papel Sulfite", false)
        {
            ID = 10,
            TipoDeItems =
            {
                new TipoDeItem("A4")
                {
                    ID = 10,
                    IDproduto = 10,
                    DepositoAtual = depositosMock[5],
                    Remessas =
                    {
                        new Remessa(20, false,
                            depositosMock[5].Nome, salasMocks[3].Nome)
                    }
                }
            }
        },

        new Produto("Pasta de Dente", false)
        {
            ID = 11,
            TipoDeItems =
            {
                new TipoDeItem("90g")
                {
                    ID = 11,
                    IDproduto = 11,
                    DepositoAtual = depositosMock[0],
                    Remessas =
                    {
                        new Remessa(50, false,
                            depositosMock[0].Nome, salasMocks[0].Nome)
                    }
                }
            }
        },

        new Produto("Escova de Dente", false)
        {
            ID = 12,
            TipoDeItems =
            {
                new TipoDeItem("Macia")
                {
                    ID = 12,
                    IDproduto = 12,
                    DepositoAtual = depositosMock[0],
                    Remessas =
                    {
                        new Remessa(80, false,
                            depositosMock[0].Nome, salasMocks[0].Nome)
                    }
                }
            }
        },

        new Produto("Desinfetante", false)
        {
            ID = 13,
            TipoDeItems =
            {
                new TipoDeItem("2L")
                {
                    ID = 13,
                    IDproduto = 13,
                    DepositoAtual = depositosMock[3],
                    Remessas =
                    {
                        new Remessa(30, false,
                            depositosMock[3].Nome, salasMocks[2].Nome)
                    }
                }
            }
        },

        new Produto("Biscoito", true)
        {
            ID = 14,
            TipoDeItems =
            {
                new TipoDeItem("Recheado")
                {
                    ID = 14,
                    IDproduto = 14,
                    DepositoAtual = depositosMock[2],
                    Remessas =
                    {
                        new Remessa(100, true, DateTime.Now.AddMonths(4),
                            depositosMock[2].Nome, salasMocks[1].Nome)
                    }
                }
            }
        },

        new Produto("Sardinha em Lata", true)
        {
            ID = 15,
            TipoDeItems =
            {
                new TipoDeItem("125g")
                {
                    ID = 15,
                    IDproduto = 15,
                    DepositoAtual = depositosMock[1],
                    Remessas =
                    {
                        new Remessa(60, true, DateTime.Now.AddYears(1),
                            depositosMock[1].Nome, salasMocks[0].Nome)
                    }
                }
            }
        },

        new Produto("Milho Verde", true)
        {
            ID = 16,
            TipoDeItems =
            {
                new TipoDeItem("Lata")
                {
                    ID = 16,
                    IDproduto = 16,
                    DepositoAtual = depositosMock[1],
                    Remessas =
                    {
                        new Remessa(40, true, DateTime.Now.AddYears(1),
                            depositosMock[1].Nome, salasMocks[0].Nome)
                    }
                }
            }
        },

        new Produto("Alcool Gel", false)
        {
            ID = 17,
            TipoDeItems =
            {
                new TipoDeItem("500ml")
                {
                    ID = 17,
                    IDproduto = 17,
                    DepositoAtual = depositosMock[3],
                    Remessas =
                    {
                        new Remessa(25, false,
                            depositosMock[3].Nome, salasMocks[2].Nome)
                    }
                }
            }
        },

        new Produto("Pão de Forma", true)
        {
            ID = 18,
            TipoDeItems =
            {
                new TipoDeItem("Tradicional")
                {
                    ID = 18,
                    IDproduto = 18,
                    DepositoAtual = depositosMock[7],
                    Remessas =
                    {
                        new Remessa(15, true, DateTime.Now.AddDays(5),
                            depositosMock[7].Nome, salasMocks[4].Nome)
                    }
                }
            }
        },

        new Produto("Margarina", true)
        {
            ID = 19,
            TipoDeItems =
            {
                new TipoDeItem("500g")
                {
                    ID = 19,
                    IDproduto = 19,
                    DepositoAtual = depositosMock[7],
                    Remessas =
                    {
                        new Remessa(30, true, DateTime.Now.AddMonths(3),
                            depositosMock[7].Nome, salasMocks[4].Nome)
                    }
                }
            }
        },

        new Produto("Farinha de Trigo", true)
        {
            ID = 20,
            TipoDeItems =
            {
                new TipoDeItem("1kg")
                {
                    ID = 20,
                    IDproduto = 20,
                    DepositoAtual = depositosMock[2],
                    Remessas =
                    {
                        new Remessa(55, true, DateTime.Now.AddMonths(9),
                            depositosMock[2].Nome, salasMocks[1].Nome)
                    }
                }
            }
        }
    };
}
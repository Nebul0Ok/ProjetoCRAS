using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCRAS.Models
{
    public class TipoDeItem
    {
        public int IDTipo { get; set; }
        public string NomeTipo { get; set; }
        public DateTime DataCadastroTipo { get; set; }
        public int QuantidadeTipoEstoque { get; set; }
        public int? QuantidadeTipoProduto { get; set; }
        public string? Medida { get; set; }
        public TipoDeItem(int IDTipo, string NomeTipo, int QuantidadeTipoEstoque, int QuantidadeTipoProduto, string Medida)
        {
            this.IDTipo = IDTipo;
            this.NomeTipo = NomeTipo;
            DataCadastroTipo = DateTime.Now;
            this.QuantidadeTipoEstoque = QuantidadeTipoEstoque;
            this.QuantidadeTipoProduto = QuantidadeTipoProduto;
            this.Medida = Medida;
        }

    }
}

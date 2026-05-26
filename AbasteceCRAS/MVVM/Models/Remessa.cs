using AbasteceCRAS.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbasteceCRAS.MVVM.Models
{
    public class Remessa
    {
        public DateTime DataRecebimento { get; set; }
        public int Quantidade {  get; set; }

        public bool IsPerecivel {  get; set; }
        public DateTime? DataValidade { get; set; }


        public Remessa(int Quantidade, bool IsPerecivel, DateTime? DataValidade)
        {
            this.DataRecebimento = DateTime.Now;
            this.Quantidade = Quantidade;
            this.IsPerecivel = IsPerecivel;
            this.DataValidade = DataValidade;
        }

        public Remessa(int Quantidade, bool IsPerecivel)
        {
            this.DataRecebimento = DateTime.Now;
            this.Quantidade = Quantidade;
            this.IsPerecivel = IsPerecivel;
            this.DataValidade = null;
        }

        public bool VerificarValidadeNotificacao()
        {

            if (DataValidade == null) return false;

            TimeSpan t = DataValidade.Value - DateTime.Now;

            if (t.TotalDays > 7)
            {
                return false;
            }
            else if(t.TotalDays > 0)
            {
                DadosService.Instance.AdicionarNotificacao("Produto prestes a estragar", $"O produto irá estragar em {Math.Abs(t.Days)} dias");
                return true;
            }
            else
            {
                DadosService.Instance.AdicionarNotificacao("Produto estragado", $"O produto estragou a {Math.Abs(t.Days)} dias");
                return true;
            }
        }
    }
}

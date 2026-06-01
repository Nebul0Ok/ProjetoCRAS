using AbasteceCRAS.Core;
using AbasteceCRAS.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbasteceCRAS.MVVM.Models
{
    public class Remessa: OnPropertyChangedHandler
    {
        public int ID { get; set; }
        public string Local { get; set; }
        public string Sala { get; set; }
        
        public DateTime DataRecebimento { get; set; }
        private int _quantidade;
        public int Quantidade
        {
            get => _quantidade;
            set
            {
                _quantidade = value;
                OnPropertyChanged();
            }
        }

        public bool IsPerecivel {  get; set; }
        public DateTime? DataValidade { get; set; }


        public Remessa(int Quantidade, bool IsPerecivel, DateTime? DataValidade, string Local, string Sala)
        {
            this.DataRecebimento = DateTime.Now;
            this.Quantidade = Quantidade;
            this.IsPerecivel = IsPerecivel;
            this.DataValidade = DataValidade;
            this.Local = Local;
            this.Sala = Sala;
        }

        public Remessa(int Quantidade, bool IsPerecivel, string Local, string Sala)
        {
            this.DataRecebimento = DateTime.Now;
            this.Quantidade = Quantidade;
            this.IsPerecivel = IsPerecivel;
            this.DataValidade = null;
            this.Local = Local;
            this.Sala = Sala;
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

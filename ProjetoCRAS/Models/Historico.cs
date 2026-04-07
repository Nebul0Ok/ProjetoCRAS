using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCRAS.Models
{
    public class Historico
    {
        public DateTime DataRegistro {  get; set; }
        public string Usuario { get; set; }
        public string Acao { get; set; }

        public List<Historico> _historico = new List<Historico>();

        public Historico(string Usuario, string Acao) {
            this.Usuario = Usuario;
            this.Acao = Acao;
            DataRegistro = DateTime.Now;
        }

        public void AdicionarHistoricoLista(Historico hist) {
            _historico.Add(hist);
        }

    }
}

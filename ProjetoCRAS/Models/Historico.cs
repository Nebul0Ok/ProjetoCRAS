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

        public static List<Historico> ListaHistorico { get; set; } = new List<Historico>();

        public Historico(string Usuario, string Acao) {
           this.Usuario = Usuario;
            this.Acao = Acao;
            this.DataRegistro = DateTime.Now;
        }

        public static void Registrar(string Usuario, string Acao)
        {
            ListaHistorico.Add(new Historico(Usuario, Acao));
        }

    }
}

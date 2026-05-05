using System.Security.Cryptography.X509Certificates;

namespace AbasteceCRAS.MVVM.Models;

public class Historico
{
    public string Ocorrencia { get; set; }
    public DateTime DataDaOcorrencia { get;set;}
    public string Responsavel { get;set; }

    public Historico(string Ocorrencia, string Responsavel)
    {
        this.Ocorrencia = Ocorrencia;
        this.Responsavel = Responsavel;
        this.DataDaOcorrencia = DateTime.Now;
    }
}

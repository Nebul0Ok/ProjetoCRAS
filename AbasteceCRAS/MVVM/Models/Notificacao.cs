using System.Security.Cryptography.X509Certificates;

namespace AbasteceCRAS.MVVM.Models;

public class Notificacao
{
    public DateTime Hora { get; set; }
    public string Header { get; set; }
    public string Body {  get; set; }

    public Notificacao(string Header, string Body)
    {
        Hora = DateTime.Now;
        this.Header = Header;
        this.Body = Body;
    }

}

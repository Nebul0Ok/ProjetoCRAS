namespace AbasteceCRAS.MVVM.Models;

public class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public Usuario(string Nome, string Email, string Senha)
    {
        this.Nome = Nome;
        this.Senha = Senha;
        this.Email = Email;
    }

    public Usuario( string Email, string Senha)
    {
        this.Senha = Senha;
        this.Email = Email;
    }

}

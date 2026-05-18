namespace AbasteceCRAS.MVVM.Models;

public class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Cargo {  get; set; }

    public Usuario(string Nome, string Email, string Senha, string cargo)
    {
        this.Nome = Nome;
        this.Senha = Senha;
        this.Email = Email;
        this.Cargo = cargo;
    }

    public Usuario( string Email, string Senha)
    {
        this.Senha = Senha;
        this.Email = Email;
    }

}

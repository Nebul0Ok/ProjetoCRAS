using AbasteceCRAS.MVVM.Models;
using System.Net.NetworkInformation;

namespace AbasteceCRAS.Services;

public class SessionService
{
    //Cria um Singleton para
    //existir dentro do programa
    //todo e conseguir acessar os dados do usuario
    private static SessionService _instance;
    public static SessionService Instance => _instance ??= new SessionService();  



    //Salva o objeto do usuario logado
    public Usuario UsuarioLogado { get; set;}



    //Cria um ID para o usuario
    public static Dictionary<int, Usuario> UsuariosCadastrados { get; set; } = new Dictionary<int, Usuario>();

    public static bool CadastrarUsuario (Usuario u)
    {
        bool cadastrado = UsuariosCadastrados.Values.Any(x => x.Email == u.Email);

        if (cadastrado) return false;

        UsuariosCadastrados.Add((UsuariosCadastrados.Count + 1), u);

        return true;
    }

    public bool LoginUsuario (string email, string senha)
    {
        var login = UsuariosCadastrados.Values.FirstOrDefault(o => o.Email == email && o.Senha == senha);

        if (login != null)
        {
            UsuarioLogado = login;
            return true;
        }
        else
        {
            return false;
        }

    }

    private SessionService() { }
}

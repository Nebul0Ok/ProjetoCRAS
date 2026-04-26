using AbasteceCRAS.MVVM.Models;
using System.Net.NetworkInformation;

namespace AbasteceCRAS.Services;

public class SessionService
{
    private static SessionService _instance;
    public static SessionService Instance => _instance ??= new SessionService();  

    public Usuario UsuarioLogado { get; set;}

    private SessionService() { }
}

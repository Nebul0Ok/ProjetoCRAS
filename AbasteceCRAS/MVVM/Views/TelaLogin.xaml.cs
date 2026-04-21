using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.MVVM.ViewModels;
using System.Windows;

namespace AbasteceCRAS.MVVM.Views;

public partial class TelaLogin : Window
{
    public static List<Usuario> UsuariosCadastrados;
    public TelaLogin()
    {
        InitializeComponent();
        this.DataContext = new LoginViewModel();
        UsuariosCadastrados = new List<Usuario>();
        Usuario u = new Usuario("Carlos", "carlos@email.com", "carlos123");
        Usuario admin = new Usuario("Admin", "admin", "admin");
        UsuariosCadastrados.Add(u);
        UsuariosCadastrados.Add(admin);
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is LoginViewModel vm)
        {
            var passwordBox = sender as System.Windows.Controls.PasswordBox;
            vm.Senha = passwordBox.Password;
        }
    }
}

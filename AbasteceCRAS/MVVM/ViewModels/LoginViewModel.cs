using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.MVVM.Views;
using AbasteceCRAS.Services;
using System.Windows;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels;

public class LoginViewModel: ViewModelBase
{
    public ICommand RealizarLogin { get;}
    private string _email;
    private string _senha;

    public string Email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(); }
    }


    public string Senha
    {
        get => _senha;
        set { _senha = value; OnPropertyChanged(); }
    }


    public LoginViewModel()
    {
        RealizarLogin = new RelayCommand(ExecutarLogin);
    }

    public void ExecutarLogin(object parameter)
    {
       
        try 
        {
            var usuarioEncontrado = TelaLogin.UsuariosCadastrados.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);

            if (usuarioEncontrado != null)
            {
                MessageBox.Show($"Logado.");
                SessionService.Instance.UsuarioLogado = usuarioEncontrado;

                if(parameter is Window currentWindow)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    currentWindow.Close();
                }

            }
            else
            {
                MessageBox.Show("Usuario não econtrado");
            }

        } 
        catch(Exception ex)
        {

        }
    }
}

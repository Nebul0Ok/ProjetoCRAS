using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.MVVM.Views;
using AbasteceCRAS.Services;
using AbasteceCRAS.Teste;
using System.Windows;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels;

public class LoginViewModel: ViewModelBase
{
    public ICommand RealizarLogin { get;}
    private string _email;
    private string _senha;

    private string _emailFeedback;
    public string EmailFeedback
    {
        get => _emailFeedback;
        set
        {
            _emailFeedback = value; OnPropertyChanged();
        }
    }

    private string _senhaFeedback;
    public string SenhaFeedback
    {
        get => _senhaFeedback;
        set
        {
            _senhaFeedback = value; OnPropertyChanged();
        }
    }

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

        foreach(var estoque in Armazens.ArmazemMock)
        {
            DadosService.Instance.ListaDeposito.Add(estoque);
        }

        foreach(var prod in Produtos.prod)
        {
            DadosService.Instance.ListaProduto.Add(prod);
        }

        EmailFeedback = string.Empty;
        SenhaFeedback = string.Empty;
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

                if (parameter is Window currentWindow)
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
        catch
        {

        }

        //SenhaFeedback = string.Empty;
        //EmailFeedback = string.Empty;

        //if (DadosService.Instance.UsuariosCadastrados.ContainsKey(Email)) {
        //    if (DadosService.Instance.UsuariosCadastrados.ContainsValue(Senha))
        //    {

        //    }
        //    else
        //    {
        //        SenhaFeedback = "Senha não encontrada";
        //    }
        //}
        //else
        //{
        //    EmailFeedback = "E-mail não encontrado";
        //    if (!DadosService.Instance.UsuariosCadastrados.ContainsValue(Senha))
        //    {
        //        SenhaFeedback = "Senha não encontrada";
        //    }
        //}

    }
}

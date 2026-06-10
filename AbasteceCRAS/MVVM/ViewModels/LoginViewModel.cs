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

        //foreach(var estoque in Armazens.ArmazemMock)
        //{
        //    DadosService.Instance.ListaDeposito.Add(estoque);
        //}

        //foreach(var prod in Produtos.prod)
        //{
        //    DadosService.Instance.AdicionarItem(prod);
        //    DadosService.Instance.SalvarHistoricoSistema($"O {prod.NomeItem} foi adicionado");
        //}

        
        if(DadosService.Instance.NotificacoesAtuais.Count == 0) DadosService.Instance.NotificacoesAtuais.Add(new Notificacao("Arroz 5kg estragou", "Arroz 5kg estragou no dia 02/06/2026. Recomenda-se remover do estoque."));


        EmailFeedback = string.Empty;
        SenhaFeedback = string.Empty;

    }

    public void ExecutarLogin(object parameter)
    {
        EmailFeedback = string.Empty;
        SenhaFeedback = string.Empty;

        
        if (String.IsNullOrWhiteSpace(Email))
        {
            EmailFeedback = "Email Vazio";
            return;
        }
        if (String.IsNullOrWhiteSpace(Senha))
        {
            SenhaFeedback = "Senha Vazia";
            return;
        }

        if (SessionService.Instance.LoginUsuario(Email, Senha))
        {
            if (parameter is Window currentWindow)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                currentWindow.Close();
            }
        }
        else
        {
            MessageBox.Show("Usuario não encontrado");
        }



    }
}

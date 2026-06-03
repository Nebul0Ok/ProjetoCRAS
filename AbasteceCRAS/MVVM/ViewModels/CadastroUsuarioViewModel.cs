using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Windows;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels;

public class CadastroUsuarioViewModel : ViewModelBase
{
    //Construtor
    public CadastroUsuarioViewModel()
    {
        RetornarHome = new RelayCommand(VoltarParaHome);
        ConfirmarCadastro = new RelayCommand(CadastrarCadastroAdmin);
    }

    //Variáveis

    private string _textNome;
    public string TextNome
    {
        get => _textNome;
        set
        {
            _textNome = value;
            OnPropertyChanged();
        }
    }

    private string _textEmail;
    public string TextEmail
    {
        get => _textEmail;
        set
        {
            _textEmail = value;
            OnPropertyChanged();
        }
    }

    private string _textSenha;
    public string TextSenha
    {
        get => _textSenha;
        set
        {
            _textSenha = value;
            OnPropertyChanged();
        }
    }

    //Botões
    public ICommand RetornarHome { get; }
    public ICommand ConfirmarCadastro {  get; }

    //Funções
    public void VoltarParaHome(object parameter)
    {
        MainViewModel.Instance.AcessarHome();
    }

    public void CadastrarCadastroAdmin(object parameter)
    {
        try
        {
            if (TextNome.Equals(string.IsNullOrWhiteSpace) || TextEmail.Equals(string.IsNullOrWhiteSpace) || TextSenha.Equals(string.IsNullOrWhiteSpace))
            {
                MessageBox.Show("Preencha todas as caixas");
                return;
            }

            Usuario u = new Usuario(TextNome, TextEmail, TextSenha, "administrador");

            if (SessionService.CadastrarUsuario(u))
            {
                MessageBox.Show("Administrador cadastrado!");
            }

        }
        catch
        {
            MessageBox.Show("Erro de criação de administrador");
        }
    }

    // Método para limpar os campos após o cadastro
}

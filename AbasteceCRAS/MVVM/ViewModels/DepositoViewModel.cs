using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels;

public class DepositoViewModel : ViewModelBase
{
    public ICommand RetornarParaHome { get;}
    public ICommand CadastrarSala {  get;}
    public ICommand AdicionarDepositoCommand { get; }

    public DepositoViewModel()
    {
        RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
        AdicionarDepositoCommand = new RelayCommand(o => Adicionar());
        CadastrarSala = new RelayCommand(CadastroSala);
    }

    public ObservableCollection<Deposito> ListaDepositos => DadosService.Instance.ListaDeposito;

    private string _nomeSalaInput;
    public string NomeSalaInput
    {
        get => _nomeSalaInput;
        set 
        {
            _nomeSalaInput = value;
            OnPropertyChanged();
        }
    }

    private string _nomeDepositoInput;
    public string NomeDepositoInput
    {
        get => _nomeDepositoInput;
        set { _nomeDepositoInput = value; OnPropertyChanged(); }
    }

    private string _localInput;
    public string LocalInput
    {
        get => _localInput;
        set { _localInput = value; OnPropertyChanged(); }
    }



    private Sala _salaSelecionada;
    public Sala SalaSelecionada
    {
        get => _salaSelecionada;
        set { _salaSelecionada = value; OnPropertyChanged(); }
    }



    private void Adicionar()
    {
        if (string.IsNullOrWhiteSpace(NomeDepositoInput)) return;               // Verifica se a caixa do nome do depósito não está vazia ou com espaços
        if (SalaSelecionada == null) return;                                    // Verifica se tem alguma coisa selecionada na ComboBox

        Deposito p = new Deposito(NomeDepositoInput, LocalInput);
        p.IdSala = SalaSelecionada.ID;
        
        // Registra na sala um novo depósito
        DadosService.Instance.AdicionarDepositoNaSala(SalaSelecionada, p);
        
        // Registra no histórico que o usuario criou um depósito numa determinada sala
        DadosService.Instance.SalvarHistorico($"Adicionado depósito {p.Nome} no local {p.Localizacao} na sala {SalaSelecionada.Nome}");
        
        LimparCampos();
    }
    private void LimparCampos()
    {
        NomeDepositoInput = string.Empty;
        LocalInput = string.Empty;
        SalaSelecionada = null;
    }

    public void CadastroSala(object parameter)
    {

        if (String.IsNullOrWhiteSpace(NomeSalaInput)) return;                   // Cancela o processo se a caixa de texto está vazia
        

        Sala sala = new Sala(NomeSalaInput);

        DadosService.Instance.AdicionarSala(sala);

        NomeSalaInput = string.Empty;                                       // Limpa a caixa de texto depois que o usuário adiciona algo
    }

}

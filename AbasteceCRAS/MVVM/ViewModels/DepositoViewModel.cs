using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels;

public class DepositoViewModel : ViewModelBase
{
    public ICommand RetornarParaHome { get;}

    public DepositoViewModel()
    {
        RetornarParaHome = new RelayCommand(o => MainViewModel.Instance.AcessarHome());
        AdicionarDepositoCommand = new RelayCommand(o => Adicionar());
    }

    public ObservableCollection<Deposito> ListaDepositos => DadosService.Instance.ListaDeposito;

    private string _nomeInput;
    public string NomeInput
    {
        get => _nomeInput;
        set { _nomeInput = value; OnPropertyChanged(); }
    }

    private string _localInput;
    public string LocalInput
    {
        get => _localInput;
        set { _localInput = value; OnPropertyChanged(); }
    }

    public ICommand AdicionarDepositoCommand { get; }

    private void Adicionar()
    {
        if (string.IsNullOrWhiteSpace(NomeInput)) return;

        Deposito p = new Deposito(NomeInput, LocalInput);

        DadosService.Instance.ListaDeposito.Add(p);
        LimparCampos();
    }

    private void LimparCampos()
    {
        NomeInput = string.Empty;
        LocalInput = string.Empty;
    }

    //Criar os demais métodos do CRUD
}

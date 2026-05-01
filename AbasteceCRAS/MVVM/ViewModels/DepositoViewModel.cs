using AbasteceCRAS.Core;
using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AbasteceCRAS.MVVM.ViewModels
{
    public class DepositoViewModel : ViewModelBase
    {
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

        private string _capacidadeInput;
        public string CapacidadeInput
        {
            get => _capacidadeInput;
            set { _capacidadeInput = value; OnPropertyChanged(); }
        }

        public ICommand AdicionarDepositoCommand { get; }

        public DepositoViewModel()
        {
            AdicionarDepositoCommand = new RelayCommand(o => Adicionar());
        }
        private void Adicionar()
        {
            if (string.IsNullOrWhiteSpace(NomeInput)) return;

            var novoDeposito = new Deposito
            {
                Nome = NomeInput,
                Localizacao = LocalInput,
                Capacidade = CapacidadeInput
            };

            DadosService.Instance.ListaDeposito.Add(novoDeposito);
            LimparCampos();
        }

        private void LimparCampos()
        {
            NomeInput = string.Empty;
            LocalInput = string.Empty;
            CapacidadeInput = string.Empty;
        }

        //Criar os demais métodos do CRUD
    }
}
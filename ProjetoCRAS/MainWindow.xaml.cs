using ProjetoCRAS.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetoCRAS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Uri("Views/TelaHome.xaml", UriKind.Relative));
        }

        public void CarregarTelaDeposito(){
            MainFrame.Navigate(new Uri("Views/TelaDeposito.xaml", UriKind.Relative));    
        }

        public void CarregarTelaItens(){
            MainFrame.Navigate(new Uri("Views/TelaItens.xaml", UriKind.Relative));    
        }

        public void CarregarTelaEstoque(){
            MainFrame.Navigate(new Uri("Views/TelaEstoque.xaml", UriKind.Relative));    
        }

        public void CarregarTelaHistorico(){
            MainFrame.Navigate(new Uri("Views/TelaHistorico.xaml", UriKind.Relative));    
        }

    }
}
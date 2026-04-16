using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetoCRAS;

namespace ProjetoCRAS.Views
{
    /// <summary>
    /// Interação lógica para TelaHome.xam
    /// </summary>
    public partial class TelaHome : UserControl
    {
        MainWindow main = (MainWindow)Application.Current.MainWindow;

        public TelaHome()
        {
            InitializeComponent();
        }

        private void BtnEstoque_Click(object sender, RoutedEventArgs e) {
            main.CarregarTelaEstoque();
        }

        private void BtnDeposito_Click(object sender, RoutedEventArgs e) {
            main.CarregarTelaDeposito();
        }

        private void BtnItens_Click(object sender, RoutedEventArgs e) {
            main.CarregarTelaItens();
        }

        private void BtnHistorico_Click(object sender, RoutedEventArgs e) {
            main.CarregarTelaHistorico();
        }

        private void BtnMenuLateral_Click(object sender, RoutedEventArgs e)
        {
            ContentMenuLateral.Content = new MenuLateral(this);
        }

        public void RemoveMenuLateral() {
            ContentMenuLateral.Content = null;
        }
    }
}

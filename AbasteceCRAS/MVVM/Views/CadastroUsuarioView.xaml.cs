using AbasteceCRAS.MVVM.ViewModels;
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

namespace AbasteceCRAS.MVVM.Views
{
    /// <summary>
    /// Interação lógica para CadastroUsuarioView.xam
    /// </summary>
    public partial class CadastroUsuarioView : UserControl
    {
        public CadastroUsuarioView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CadastroUsuarioViewModel vm)
            {
                var passwordBox = sender as PasswordBox;
                vm.TextSenha = passwordBox?.Password;
            }
        }
    }
}

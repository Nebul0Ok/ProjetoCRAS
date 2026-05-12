using AbasteceCRAS.MVVM.Models;
using AbasteceCRAS.MVVM.ViewModels;
using AbasteceCRAS.Services;
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

namespace AbasteceCRAS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isFullscreen = true;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11) {
                if (!isFullscreen)
                {
                    WindowStyle = WindowStyle.None;
                    WindowState = WindowState.Maximized;
                    ResizeMode = ResizeMode.NoResize;
                    isFullscreen = true;
                }
                else
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    WindowState = WindowState.Normal;
                    ResizeMode = ResizeMode.CanResize;
                    isFullscreen = false;
                }

            }
        }
    }
}
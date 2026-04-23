using AbasteceCRAS.MVVM.ViewModels;
using AbasteceCRAS.MVVM.Views;
using AbasteceCRAS.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AbasteceCRAS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection ();

            services.AddSingleton<MainWindow>(ServiceProvider => new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<MainViewModel>() 
            });

            services.AddSingleton<TelaLogin>( ServiceProvider => new TelaLogin
            {
                DataContext = ServiceProvider.GetRequiredService<LoginViewModel>()
            });

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<NavigateService>();

            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType =>(ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            var telaLogin = _serviceProvider.GetRequiredService<TelaLogin>();
            telaLogin.Show();
            base.OnStartup(e);
        }
    }

}

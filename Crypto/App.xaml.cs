using System.Configuration;
using System.Data;
using System.Windows;
using Crypto.Core;
using Crypto.MVVM.ViewModel;
using Crypto.Services;
using Crypto.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Crypto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<ItemViewModel>();
            services.AddSingleton<SearchViewModel>();
            services.AddSingleton<ConverterViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, BaseViewModel>>(provider => 
                viewModelType => (BaseViewModel)provider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            
            mainWindow.Show();
            
            base.OnStartup(e);
        }
    }
}
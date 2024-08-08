using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.Core;
using Crypto.MVVM.View;
using Crypto.Services.Interfaces;

namespace Crypto.MVVM.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHomeViewCommand { get; set; }
        public RelayCommand NavigateToConverterViewCommand { get; set; }
        public RelayCommand NavigateToItemViewCommand { get; set; }
        public RelayCommand NavigateToSearchViewCommand { get; set; }

        public MainWindowViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateToHomeViewCommand = new RelayCommand(o => true, o =>
            {
                NavigationService.Navigate<HomeViewModel>();
            });

            NavigateToConverterViewCommand = new RelayCommand(o => true, o =>
            {
                NavigationService.Navigate<ConverterViewModel>();
            });

            NavigateToItemViewCommand = new RelayCommand(o => true, o =>
            {
                NavigationService.Navigate<ItemViewModel>();
            });

            NavigateToSearchViewCommand = new RelayCommand(o => true, o =>
            {
                NavigationService.Navigate<SearchViewModel>();
            });
        }
    }
}
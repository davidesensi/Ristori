using Ristori.Models;
using Ristori.Services;
using Ristori.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ristori.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private string _UserName;
        public string UserName
        {
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserName;
            }
        }

        private int _OperatorCartProductsCount;
        public int OperatorCartProductsCount
        {
            set
            {
                _OperatorCartProductsCount = value;
                OnPropertyChanged();
            }
            get
            {
                return _OperatorCartProductsCount;
            }
        }

        public ObservableCollection<Category> Categories { get; set; }

        public Command ViewCartCommand { get; set; }

        public Command SettingsSpageCommand { get; set; }
        public Command LogoutCommand { get; set; }

        public ProductsViewModel()
        {
            var oname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(oname))
                UserName = "Guest";
            else
                UserName = oname;

            OperatorCartProductsCount = new CartProductService().GetOperatorCartCount();

            Categories = new ObservableCollection<Category>();

            ViewCartCommand = new Command(async () => await ViewCartAsync());
            SettingsSpageCommand = new Command(async () => await SettingsSpageAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());

            GetCategories();
        }

        private async Task LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        private async Task SettingsSpageAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SettingsPage());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async void GetCategories()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var category in data)
            {
                Categories.Add(category);
            }
        }
    }
}

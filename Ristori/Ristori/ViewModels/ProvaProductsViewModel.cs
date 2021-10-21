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
    public class ProvaProductsViewModel : BaseViewModel
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

        public ObservableCollection<Product> Products { get; set; }

        public ProvaProductsViewModel()
        {
            var oname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(oname))
                UserName = "Guest";
            else
                UserName = oname;

            Products = new ObservableCollection<Product>();

            GetProducts();
        }

        private async void GetProducts()
        {
            var data = await new ProductService().GetProductAsync();
            Products.Clear();
            foreach (var category in data)
            {
                Products.Add(category);
            }
        }
    }
}

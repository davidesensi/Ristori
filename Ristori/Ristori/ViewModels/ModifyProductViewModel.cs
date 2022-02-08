using Ristori.Models;
using Ristori.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ristori.ViewModels
{
    public class ModifyProductViewModel : BaseViewModel
    {
        private Product _Product;

        private ObservableCollection<Category> _Categories;

        private ObservableCollection<Product> _AllProducts;

        public Command UpdateProductCommand { get; set; }


        public ObservableCollection<Category> Categories
        {
            set
            {
                _Categories = value;
                OnPropertyChanged();
            }
            get
            {
                return _Categories;
            }
        }

        public ObservableCollection<Product> AllProducts
        {
            set
            {
                _AllProducts = value;
                OnPropertyChanged();
            }
            get
            {
                return _AllProducts;
            }
        }

        public Product Product
        {
            set
            {
                this._Product = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Product;
            }
        }

        public ModifyProductViewModel()
        {
            Product = new Product();
            Categories = new ObservableCollection<Category>();
            AllProducts = new ObservableCollection<Product>();

            _ = GetCategoriesAsync();
            _ = GetAllProductsAsync();

            UpdateProductCommand = new Command(async () => await UpdateProduct());
        }

        private async Task UpdateProduct()
        {
            if (Product.Name == null)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", "Devi Inserire il nome!", "OK");
            }
            else if (Product.Description == null)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", "Devi Inserire la descrizione!", "OK");
            }
            else if (Product.Price == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", "Devi Inserire il prezzo!", "OK");
            }
            else
            {
                _ = new ProductService().UpdateProduct(Product);
                await Shell.Current.Navigation.PopAsync();
            }
        }

        private async Task GetCategoriesAsync()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var category in data)
            {
                Categories.Add(category);
            }
        }

        private async Task GetAllProductsAsync()
        {
            var data = await new ProductService().GetAllProducts();
            AllProducts.Clear();
            foreach (var product in data)
            {
                AllProducts.Add(product);
            }
        }
    }
}

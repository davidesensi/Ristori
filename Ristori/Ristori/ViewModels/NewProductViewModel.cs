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
    public class NewProductViewModel : BaseViewModel
    {
        private Product _Product;

        private ObservableCollection<Category> _Categories;
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

        public Command AddProductCommand { get; set; }
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

        public Category CategorySelected { get; set; }

        public NewProductViewModel()
        {
            Product = new Product();
            CategorySelected = new Category();
            Categories = new ObservableCollection<Category>();
            GetCategoriesAsync();
            AddProductCommand = new Command(async () => await AddNewProduct());
        }

        private async Task AddNewProduct()
        {
            if (Product.Name == null)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", "Devi Inserire il nome!", "OK");
            }
            else if (Product.Description == null)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", "Devi Inserire la descrizione!", "OK");
            }
            else if (Product.Price == null)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", "Devi Inserire il prezzo!", "OK");
            }
            else
            {
                Product.CategoryID = CategorySelected.CategoryID;
                new ProductService().AddNewProduct(Product);
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

    }
}

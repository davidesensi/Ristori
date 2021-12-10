using Ristori.Models;
using Ristori.Services;
using Ristori.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ristori.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedCategory;
            }
           

        }

        private int _SelectedCategoryID;
        public int SelectedCategoryID
        {
            set
            {
                _SelectedCategoryID = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedCategoryID;
            }


        }

        public ObservableCollection<Product> ProductsByCategory { get; set; }

        private int _TotalProducts;
        public int TotalProducts
        {
            set
            {
                _TotalProducts = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalProducts;
            }
        }

        public Command IncrementOrderCommand { get; set; }
        public Command InfoProductCommand { get; set; }


        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            ProductsByCategory = new ObservableCollection<Product>();
            GetProductsAsync(category.CategoryID);
            IncrementOrderCommand = new Command(IncrementOrder);
            InfoProductCommand = new Command(InfoProduct);
            
        }

        public CategoryViewModel(int categoryID)
        {
            SelectedCategoryID = categoryID;
            ProductsByCategory = new ObservableCollection<Product>();
            GetProductsAsync(categoryID);
            IncrementOrderCommand = new Command(IncrementOrder);
            InfoProductCommand = new Command(InfoProduct);
            

        }
        private async Task GetProductsAsync(int categoryID)
        {
            var data = await new ProductService().GetProductsByCategoryAsync(categoryID);
            ProductsByCategory.Clear();
            foreach(var product in data)
            {
                ProductsByCategory.Add(product);
            }
        }

        

        private void InfoProduct(Object obj)
        {
            var product = obj as Product;
            //Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsView(product));
            Shell.Current.Navigation.PushAsync(new ProductDetailsView(product));
        }

        private void IncrementOrder(Object obj)
        {
            SQLite.SQLiteConnection cn = DependencyService.Get<ISQLite>().GetConnection();
            var selectedProduct = obj as Product;

            try
            {
                CartItem cartItem = new CartItem()
                {
                    ProductID = selectedProduct.ProductID,
                    ProductName = selectedProduct.Name,
                    Price = selectedProduct.Price,
                    Quantity = 1
                };

                var product = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.ProductID == selectedProduct.ProductID);
                if (product == null)
                    cn.Insert(cartItem);
                else
                {
                    product.Quantity ++;
                    cn.Update(product);
                }
                cn.Commit();
                cn.Close();
                Vibration.Vibrate();
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                cn.Close();
            }
        }


    }
}

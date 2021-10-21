using Ristori.Models;
using Ristori.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        

        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            ProductsByCategory = new ObservableCollection<Product>();
            _ = GetProductsAsync(category.CategoryID);
            /*TotalQuantity = 0;

            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());*/
        }

        public CategoryViewModel(int categoryID)
        {
            SelectedCategoryID = categoryID;
            ProductsByCategory = new ObservableCollection<Product>();
            _ = GetProductsAsync(categoryID);
            
        }
        private async Task GetProductsAsync(int categoryID)
        {
            var data = await new ProductService().GetProductsByCategoryAsync(categoryID);
            ProductsByCategory.Clear();
            foreach(var product in data)
            {
                ProductsByCategory.Add(product);
            }
            TotalProducts = ProductsByCategory.Count;
        }

        /*private async Task GetProductsByNameAsync(string categoryName)
        {
            var data = await new ProductService().GetProductsByNameByCategoryAsync(categoryName);
            ProductsByCategory.Clear();
            foreach (var product in data)
            {
                ProductsByCategory.Add(product);
            }
            TotalProducts = ProductsByCategory.Count;
        }

        private void AddToCart()
        {
            SQLite.SQLiteConnection cn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                CartItem cartItem = new CartItem()
                {
                    ProductID = SelectedProduct.ProductID,
                    ProductName = SelectedProduct.Name,
                    Price = SelectedProduct.Price,
                    Quantity = TotalQuantity
                };

                var product = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.ProductID == SelectedProduct.ProductID);
                if (product == null)
                    cn.Insert(cartItem);
                else
                {
                    if (TotalQuantity == 0)
                    {
                        Application.Current.MainPage.DisplayAlert("Error", "Devi inserire almeno un prodotto", "OK");
                    }
                    else
                    {
                        product.Quantity += TotalQuantity;
                        cn.Update(product);
                    }
                }
                cn.Commit();
                cn.Close();
                Application.Current.MainPage.DisplayAlert("Carrello", "Prodotto aggiunto al carrello", "OK");
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

        private void DecrementOrder()
        {
            TotalQuantity--;
        }

        private void IncrementOrder()
        {
            TotalQuantity++;
        }*/


    }
}

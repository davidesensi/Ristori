using Ristori.Models;
using Ristori.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ristori.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        private Product _SelectedProduct;
        public Product SelectedProduct
        {
            set
            {
                _SelectedProduct = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedProduct;
            }
        }

        private int _TotalQuantity;
        public int TotalQuantity
        {
            set
            {
                _TotalQuantity = value;
                if (this._TotalQuantity < 0)
                    this._TotalQuantity = 0;
                if (this._TotalQuantity > 10)
                    this._TotalQuantity -= 1;
                OnPropertyChanged();
            }
            get
            {
                return _TotalQuantity;
            }
        }

        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }

        public ProductDetailsViewModel(Product product)
        {
            SelectedProduct = product;
            TotalQuantity = 0;

            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(async () => await ViewCartAsync());
            HomeCommand = new Command(async () => await HomeAsync());
        }

        private async Task HomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
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
                    if(TotalQuantity == 0)
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
        }
    }
}

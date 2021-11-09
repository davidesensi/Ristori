using Ristori.Models;
using Ristori.Services;
using Ristori.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ristori.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private ObservableCollection<CartItem> _CartItems;
        public ObservableCollection<CartItem> CartItems
        {
            set
            {
                _CartItems = value;
                OnPropertyChanged();
            }
            get
            {
                return _CartItems;
            }
        }

        public decimal _TotalCost;
        public decimal TotalCost
        {
            set
            {
                _TotalCost = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalCost;
            }
        }

        private int _Quantity;
        public int Quantity
        {
            set
            {
                _ = value;
                if (this._Quantity < 0)
                    this._Quantity = 0;
                if (this._Quantity > 10)
                    this._Quantity -= 1;
                OnPropertyChanged();
            }
            get
            {
                return _Quantity;
            }
        }

        public Command PlaceOrdersCommand { get; set; }

        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }

        public CartViewModel()
        {
            CartItems = new ObservableCollection<CartItem>();
            LoadItems();
            PlaceOrdersCommand = new Command(async () => await PlaceOrdersAsync());
            IncrementOrderCommand = new Command(IncrementOrder);
            DecrementOrderCommand = new Command(DecrementOrder);
        }

        
        private async Task PlaceOrdersAsync()
        {
            
            if (CartItems.Count() == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Carrello vuoto", "OK");
            }
            else
            {
                var id = await new OrderService().PlaceOrderAsync() as string;
                RemoveItemsFromCart();
                
                await Application.Current.MainPage.Navigation.PushModalAsync(new OrderDetailView(id));
            }
                
            
        }

        private void RemoveItemsFromCart()
        {
            var cis = new CartProductService();
            cis.RemoveProductsFromCart();
        }

        private void LoadItems()
        {
            TotalCost = 0;
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var items = cn.Table<CartItem>().ToList();
            CartItems.Clear();
            CartItems = new ObservableCollection<CartItem>();
            foreach(var item in items)
            {
                CartItems.Add(new CartItem()
                {
                    CartItemID = item.CartItemID,
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                    

                });
                TotalCost += item.Price * item.Quantity;
            }
        }

        

        /*private void AddToCart()
        {
            SQLite.SQLiteConnection cn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                CartItem cartItem = new CartItem()
                {
                    ProductID = SelectedProduct.ProductID,
                    ProductName = SelectedProduct.ProductName,
                    Price = SelectedProduct.Price,
                    Quantity = SelectedProduct.Quantity
                };

                var product = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.ProductID == SelectedProduct.ProductID);
                if (product == null)
                    cn.Insert(cartItem);
                else
                {
                    if (Quantity == 0)
                    {
                        Application.Current.MainPage.DisplayAlert("Error", "Devi inserire almeno un prodotto", "OK");
                    }
                    else
                    {
                        product.Quantity += Quantity;
                        cn.Update(product);
                    }
                }
                cn.Commit();
                cn.Close();
                Application.Current.MainPage.DisplayAlert("Carrello", "Quantita prodotto modificata nel carrello", "OK");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                cn.Close();
            }
        }*/

        private void DecrementOrder(Object obj)
        {
            SQLite.SQLiteConnection cn = DependencyService.Get<ISQLite>().GetConnection();
            var selectedProduct = obj as CartItem;
            
            var product = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.CartItemID == selectedProduct.CartItemID);
            product.Quantity--;
            cn.Update(product);
            cn.Commit();
            cn.Close();
            LoadItems();

        }

        private void IncrementOrder(Object obj)
        {
            SQLite.SQLiteConnection cn = DependencyService.Get<ISQLite>().GetConnection();
            var selectedProduct = obj as CartItem;

            var product = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.CartItemID == selectedProduct.CartItemID);
            product.Quantity++;
            cn.Update(product);
            cn.Commit();
            cn.Close();
            LoadItems();
        }

    }
}

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

        private Order _Order;
        public Order Order
        {
            set
            {
                _Order = value;
                OnPropertyChanged();
            }
            get
            {
                return _Order;
            }
        }

        public Command PlaceOrdersCommand { get; set; }
        public Command PlaceOrdersCommand2 { get; set; }
        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command DeleteRowCommand { get; set; }
        public string TavoloSelected { get; set; }

        public CartViewModel()
        {
            CartItems = new ObservableCollection<CartItem>();
            LoadItems();
            Order = new Order();
            PlaceOrdersCommand = new Command(async () => await PlaceOrdersAsync());
            PlaceOrdersCommand2 = new Command(async () => await PlaceOrdersAsync2());
            IncrementOrderCommand = new Command(IncrementOrder);
            DecrementOrderCommand = new Command(DecrementOrder);
            DeleteRowCommand = new Command(DeleteRow);
        }

        
        private async Task PlaceOrdersAsync()
        {
            
            if (CartItems.Count() == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Carrello vuoto", "OK");
            }
            else if (TotalCost == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ordine Vuoto", "OK");
            }
            else if(Order.DeliveryAddress==null && Order.DeliverySurname==null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Inserisci Cognome e Indirizzo", "OK");
            }
            else
            {
                Order.OrderMakedTime = DateTime.Now.TimeOfDay;
                Order.OrderMakedDate = DateTime.Now;
                var id = await new OrderService().PlaceOrderAsync(Order) as string;
                RemoveItemsFromCart();
                Application.Current.MainPage = new ShellView();
            }
        }

        private async Task PlaceOrdersAsync2()
        {

            if (CartItems.Count() == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Carrello vuoto", "OK");
            }
            else if (TotalCost == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ordine Vuoto", "OK");
            }
            else
            {
                Order.ComandaTavolo = TavoloSelected;
                Order.OrderMakedTime = DateTime.Now.TimeOfDay;
                Order.OrderMakedDate = DateTime.Now;
                var id = await new OrderService().PlaceOrderAsync(Order) as string;
                RemoveItemsFromCart();
                Application.Current.MainPage = new ShellView();
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

        

        private void DeleteRow(Object obj)
        {
            SQLite.SQLiteConnection cn = DependencyService.Get<ISQLite>().GetConnection();
            var selectedProduct = obj as CartItem;
            var product = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.CartItemID == selectedProduct.CartItemID);

            cn.Delete(product);
            cn.Commit();
            cn.Close();
            LoadItems();

        }

        private void DecrementOrder(Object obj)
        {
            SQLite.SQLiteConnection cn = DependencyService.Get<ISQLite>().GetConnection();
            var selectedProduct = obj as CartItem;
            
            var product = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.CartItemID == selectedProduct.CartItemID);
            if(product.Quantity <= 1)
            {
                DeleteRow(product);
            }
            else
            {
                product.Quantity--;
                cn.Update(product);
                cn.Commit();
                cn.Close();
                LoadItems();
            }
            
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

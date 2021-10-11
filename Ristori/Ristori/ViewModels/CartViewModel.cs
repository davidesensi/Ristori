﻿using Ristori.Models;
using Ristori.Services;
using Ristori.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ristori.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableCollection<OperatorCartItem> CartItems { get; set; }

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

        public Command PlaceOrdersCommand { get; set; }

        public CartViewModel()
        {
            CartItems = new ObservableCollection<OperatorCartItem>();
            LoadItems();
            PlaceOrdersCommand = new Command(async () => await PlaceOrdersAsync());
        }

        private async Task PlaceOrdersAsync()
        {
            var id = await new OrderService().PlaceOrderAsync() as string;
            RemoveItemsFromCart();
            await Application.Current.MainPage.Navigation.PushModalAsync(new OrdersView(id));
        }

        private void RemoveItemsFromCart()
        {
            var cis = new CartProductService();
            cis.RemoveProductsFromCart();
        }

        private void LoadItems()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var items = cn.Table<CartItem>().ToList();
            CartItems.Clear();
            foreach(var item in items)
            {
                CartItems.Add(new OperatorCartItem()
                {
                    CartItemID = item.CartItemID,
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Cost = item.Price * item.Quantity

                });
                TotalCost += (item.Price * item.Quantity);
            }
        }
    }
}

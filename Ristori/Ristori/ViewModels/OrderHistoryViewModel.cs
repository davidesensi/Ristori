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
    class OrderHistoryViewModel : BaseViewModel
    {
        private ObservableCollection<Order> _OrderHistoryItems;
        private ObservableCollection<Order> _OrderHistoryItemsTavolo;
        public ObservableCollection<Order> OrderHistoryItems
        {
            set
            {
                _OrderHistoryItems = value;
                OnPropertyChanged();
            }
            get
            {
                return _OrderHistoryItems;
            }
        }

        public ObservableCollection<Order> OrderHistoryItemsTavolo
        {
            set
            {
                _OrderHistoryItemsTavolo = value;
                OnPropertyChanged();
            }
            get
            {
                return _OrderHistoryItemsTavolo;
            }
        }

        public OrderHistoryViewModel()
        {
            OrderHistoryItems = new ObservableCollection<Order>();
            OrderHistoryItemsTavolo = new ObservableCollection<Order>();
            _ = GetAllOrdersAsync();
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

        public async Task GetAllOrdersAsync()
        {
            var data = await new OrderService().GetAllOrderAsync();
            OrderHistoryItems.Clear();
            foreach (var order in data)
            {
                if (order.ComandaTavolo == null)
                    OrderHistoryItems.Add(order);
                else
                    OrderHistoryItemsTavolo.Add(order);
            }
        }
        
    }
}

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
        private ObservableCollection<Order> _OrderHistoryItemsDeliveryNow;
        private ObservableCollection<Order> _OrderHistoryItemsTavoloNow;
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

        public ObservableCollection<Order> OrderHistoryItemsDeliveryNow
        {
            set
            {
                _OrderHistoryItemsDeliveryNow = value;
                OnPropertyChanged();
            }
            get
            {
                return _OrderHistoryItemsDeliveryNow;
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

        public ObservableCollection<Order> OrderHistoryItemsTavoloNow
        {
            set
            {
                _OrderHistoryItemsTavoloNow = value;
                OnPropertyChanged();
            }
            get
            {
                return _OrderHistoryItemsTavoloNow;
            }
        }

        public OrderHistoryViewModel()
        {
            OrderHistoryItems = new ObservableCollection<Order>();
            OrderHistoryItemsTavolo = new ObservableCollection<Order>();
            OrderHistoryItemsDeliveryNow = new ObservableCollection<Order>();
            OrderHistoryItemsTavoloNow = new ObservableCollection<Order>();
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
            //var DataNow = DateTime.Now;
            OrderHistoryItems.Clear();
            //OrderHistoryItemsDeliveryNow.Clear();
            //SOrderHistoryItemsTavolo.Clear();
            foreach (var order in data)
            {
                if (order.ComandaTavolo == null )
                    OrderHistoryItems.Add(order);
                if (order.ComandaTavolo != null)
                    OrderHistoryItemsTavolo.Add(order);
                if (order.ComandaTavolo == null && order.DeliveryDate.Day.Equals(DateTime.Now.Day)
                                                && order.DeliveryDate.Month.Equals(DateTime.Now.Month)
                                                && order.DeliveryDate.Year.Equals(DateTime.Now.Year))
                    OrderHistoryItemsDeliveryNow.Add(order);
                if (order.ComandaTavolo != null && order.DeliveryDate.Day.Equals(DateTime.Now.Day)
                                                && order.DeliveryDate.Month.Equals(DateTime.Now.Month)
                                                && order.DeliveryDate.Year.Equals(DateTime.Now.Year))
                    OrderHistoryItemsTavoloNow.Add(order);
            }
        }
        
    }
}

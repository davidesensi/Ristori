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
        private ObservableCollection<OrderDetails> _CurrentOrderDetails;
        private Order _CurrentOrder;

        public Command InfoCommand { get; set; }

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

        public Order CurrentOrder
        {
            set
            {
                _CurrentOrder = value;
                OnPropertyChanged();
            }
            get
            {
                return _CurrentOrder;
            }
        }

        public ObservableCollection<OrderDetails> CurrentOrderDetails
        {
            set
            {
                _CurrentOrderDetails = value;
                OnPropertyChanged();
            }
            get
            {
                return _CurrentOrderDetails;
            }
        }

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
            CurrentOrderDetails = new ObservableCollection<OrderDetails>();
            CurrentOrder = new Order();
            InfoCommand = new Command(InfoOrder);
            _ = GetAllOrdersAsync();
        }

        private async void InfoOrder(Object obj)
        {
            CurrentOrderDetails.Clear();
            CurrentOrder = obj as Order;
            CurrentOrderDetails = await new OrderService().GetOrderDetailsObservable(CurrentOrder);
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

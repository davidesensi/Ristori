using Ristori.Models;
using Ristori.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Ristori.ViewModels
{
    class OrderHistoryViewModel : BaseViewModel
    {
        private ObservableCollection<Order> _OrderHistoryItems;
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

        public OrderHistoryViewModel()
        {
            OrderHistoryItems = new ObservableCollection<Order>();
            _ = GetAllOrdersAsync();
        }

        public async Task GetAllOrdersAsync()
        {
            var data = await new OrderService().GetAllOrderAsync();
            OrderHistoryItems.Clear();
            foreach(var order in data)
            {
                OrderHistoryItems.Add(order);
            }
        }
        
    }
}

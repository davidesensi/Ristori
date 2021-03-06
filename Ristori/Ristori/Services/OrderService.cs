using Firebase.Database;
using Firebase.Database.Query;
using Ristori.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ristori.Services
{
    public class OrderService
    {
        FirebaseClient client;



        public OrderService()
        {
            client = new FirebaseClient("https://ristori-1955c-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<OrderDetails>> GetOrderDetailsAsync(Order currentOrder)
        {
            var orderDetails = (await client.Child("OrderDetails")
                .OnceAsync<OrderDetails>())
                .Select(o => new OrderDetails
                {
                    OrderDetailID = o.Object.OrderDetailID,
                    OrderID = o.Object.OrderID,
                    Price = o.Object.Price,
                    Quantity = o.Object.Quantity,
                    ProductID = o.Object.ProductID,
                    ProductName = o.Object.ProductName
                }).Where(o => o.OrderID == currentOrder.OrderID).ToList();
            return orderDetails;
        }

        public async Task<ObservableCollection<OrderDetails>> GetOrderDetailsObservable(Order currentOrder) 
        {
            var orderDetails = (await GetOrderDetailsAsync(currentOrder));
            var orderDetailsTaked = new ObservableCollection<OrderDetails>();

            foreach (var od in orderDetails) 
            {
                orderDetailsTaked.Add(od);                                             
            }

            return orderDetailsTaked;
        }


        public async Task<string> PlaceOrderAsync(Order delivery)
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<CartItem>().ToList();


            string orderID = DateTime.Now.ToShortDateString() + "-" + new Random().Next(1, 10000);
            var oname = Preferences.Get("Username", "Guest");

            decimal totalCost = 0;

            foreach(var item in data)
            {
                OrderDetails od = new OrderDetails()
                {
                    OrderID = orderID,
                    OrderDetailID = Guid.NewGuid().ToString(),
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                };
                totalCost += item.Price * item.Quantity;
                await client.Child("OrderDetails").PostAsync(od);

            }

            await client.Child("Orders").PostAsync(
                new Order()
                {
                    OrderID = orderID,
                    Username = oname,
                    TotalCost = totalCost,
                    Note = delivery.Note,
                    ComandaTavolo = delivery.ComandaTavolo,
                    OrderMakedTime = delivery.OrderMakedTime,
                    OrderMakedDate = delivery.OrderMakedDate,
                    DeliveryAddress = delivery.DeliveryAddress,
                    DeliverySurname = delivery.DeliverySurname,
                    DeliveryPhone = delivery.DeliveryPhone,
                    DeliveryDate = delivery.DeliveryDate,
                    DeliveryDateTime = delivery.DeliveryDateTime
                });
            return orderID;
        }

        public async Task<List<Order>> GetAllOrderAsync()
        {
            
            var orders = (await client.Child("Orders")
                .OnceAsync<Order>())
                .Select(o => new Order
                {
                    OrderID = o.Object.OrderID,
                    Username = o.Object.Username,
                    TotalCost = o.Object.TotalCost,
                    Note = o.Object.Note,
                    ComandaTavolo = o.Object.ComandaTavolo,
                    OrderMakedTime = o.Object.OrderMakedTime,
                    OrderMakedDate = o.Object.OrderMakedDate,
                    DeliveryAddress = o.Object.DeliveryAddress,
                    DeliveryPhone = o.Object.DeliveryPhone,
                    DeliverySurname = o.Object.DeliverySurname,
                    DeliveryDate = o.Object.DeliveryDate,
                    DeliveryDateTime = o.Object.DeliveryDateTime
                }).ToList();
            return orders;
        }
    }
}

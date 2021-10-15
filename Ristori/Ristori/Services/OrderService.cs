using Firebase.Database;
using Firebase.Database.Query;
using Ristori.Models;
using System;
using System.Collections.Generic;
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

        public async Task<string> PlaceOrderAsync()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<CartItem>().ToList();


            var orderID = Guid.NewGuid().ToString().Substring(24).ToUpper();
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
                    TotalCost = totalCost
                });
            return orderID;
        }
    }
}

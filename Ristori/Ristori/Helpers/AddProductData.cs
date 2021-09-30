using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Ristori.Models;
using Xamarin.Forms;

namespace Ristori.Helpers
{
    class AddProductData
    {
        FirebaseClient client;
        public List<Product> Products { get; set; }

        public AddProductData()
        {
            client = new FirebaseClient("https://ristori-1955c-default-rtdb.europe-west1.firebasedatabase.app/");

            //lista dei prodotti
            Products = new List<Product>() 
            {
                new Product
                {
                    ProductID = 1,
                    CategoryID = 1,
                    Name = "Suppli",
                    Description ="Suppli con riso, pomodoro, mozzarella impanato e fritto",
                    Price = 1
                },
                new Product
                {
                    ProductID = 2,
                    CategoryID = 2,
                    Name = "Pizza Margherita",
                    Description ="Pizza con pomodoro e mozzarella",
                    Price = 6
                },
                new Product
                {
                    ProductID = 3,
                    CategoryID = 3,
                    Name = "Tiramisu",
                    Description ="Dolce con mascarpone, biscotti bagnati nel caffe e cacao sopra",
                    Price = 4
                }
            };
        }

        public async Task AddProductAsync()
        {
            try
            {
                foreach(var product in Products)
                {
                    await client.Child("Products").PostAsync(new Product()
                    {
                        CategoryID = product.CategoryID,
                        ProductID = product.ProductID,
                        Description = product.Description,
                        Price = product.Price,
                        Name = product.Name
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}

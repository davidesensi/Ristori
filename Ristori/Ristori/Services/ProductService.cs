using Firebase.Database;
using Ristori.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace Ristori.Services
{
    class ProductService
    {
        FirebaseClient client;
        public ProductService()
        {
            client = new FirebaseClient("https://ristori-1955c-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<Product>> GetProductAsync()
        {
            var products = (await client.Child("Products")
                .OnceAsync<Product>())
                .Select(p => new Product
                {
                    CategoryID = p.Object.CategoryID,
                    Name = p.Object.Name,
                    ProductID = p.Object.ProductID,
                    Description = p.Object.Description,
                    Price = p.Object.Price,
                    ImageUrl = p.Object.ImageUrl
                }).ToList();
            return products;
        }

        public async Task<ObservableCollection<Product>> GetProductsByCategoryAsync(int categoryID)
        {
            var productsByCategory = new ObservableCollection<Product>();
            var products = (await GetProductAsync()).Where(p => p.CategoryID == categoryID).ToList();

            foreach(var product in products)
            {
                productsByCategory.Add(product);
            }
            return productsByCategory;
        }
    }
}

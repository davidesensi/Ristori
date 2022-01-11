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
                    Price = p.Object.Price
                }).ToList();
            return products;
        }

        public async Task<ObservableCollection<Product>> GetProductsByCategoryAsync(int categoryID)
        {
            var productsByCategory = new ObservableCollection<Product>();
            var products = (await GetProductAsync()).Where(p => p.CategoryID == categoryID).ToList();

            foreach (var product in products)
            {
                productsByCategory.Add(product);
            }
            return productsByCategory;
        }

        public async Task AddNewProduct(Product product)
        {
            var prodID = (await GetProductAsync()).Count;
            await client.Child("Products").PostAsync(new Product()
            {
                CategoryID = product.CategoryID,
                ProductID = prodID++,
                Description = product.Description,
                Price = product.Price,
                Name = product.Name
            });
        }

    }
}

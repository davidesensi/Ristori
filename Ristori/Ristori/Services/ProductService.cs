using Firebase.Database;
using Ristori.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

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

        public async Task<ObservableCollection<Product>> GetAllProducts()
        {
            var allProducts = new ObservableCollection<Product>();
            var products = (await GetProductAsync()).ToList();

            foreach (var product in products)
            {
                allProducts.Add(product);
            }
            return allProducts;
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

        public async Task UpdateProduct(Product product)
        {
            var toUpdateProduct = (await client.Child("Products").OnceAsync<Product>())
                .Where(a => a.Object.ProductID == product.ProductID).FirstOrDefault();

            await client.Child("Products").Child(toUpdateProduct.Key)
                .PutAsync(new Product()
                {
                    CategoryID = product.CategoryID,
                    ProductID = product.ProductID,
                    Description = product.Description,
                    Price = product.Price,
                    Name = product.Name
                });
        }
    }
}

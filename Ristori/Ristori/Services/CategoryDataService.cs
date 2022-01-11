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
    public class CategoryDataService
    {
        FirebaseClient client;

        public CategoryDataService()
        {
            client = new FirebaseClient("https://ristori-1955c-default-rtdb.europe-west1.firebasedatabase.app/");

        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories")
                .OnceAsync<Category>())
                .Select(c => new Category
                {
                    CategoryID = c.Object.CategoryID,
                    CategoryName = c.Object.CategoryName,
                    CategoryPoster = c.Object.CategoryPoster,
                    ImageUrl = c.Object.ImageUrl
                }).ToList();
            return categories;
        }

        public async Task<ObservableCollection<Category>> GetCategoriesObservableAsync()
        {
            var Categories = new ObservableCollection<Category>();
            var list = (await GetCategoriesAsync());

            foreach(var category in list)
            {
                Categories.Add(category);
            }
            return Categories;
        }
    }
}

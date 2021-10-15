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
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }
        FirebaseClient client;
        public AddCategoryData()
        {
            client = new FirebaseClient("https://ristori-1955c-default-rtdb.europe-west1.firebasedatabase.app/");
            Categories = new List<Category>()
            {
                new Category(){
                CategoryID = 1,
                    CategoryName = "Fritti",
                    CategoryPoster = "MainPizza.png",
                    ImageUrl = "Pizza.png"
                },
                new Category(){
                 CategoryID = 2,
                 CategoryName = "Pizze Rosse",
                 CategoryPoster = "MainPizza.png",
                 ImageUrl = "Pizza.png"
                },
                new Category(){
                 CategoryID = 3,
                 CategoryName = "Pizze Bianche",
                 CategoryPoster = "MainPizza.png",
                 ImageUrl = "Pizza.png"
                },
                new Category(){
                 CategoryID = 4,
                 CategoryName = "Dolci",
                 CategoryPoster = "MainPizza.png",
                 ImageUrl = "Pizza.png"
                },
                new Category(){
                 CategoryID = 5,
                 CategoryName = "Bevande",
                 CategoryPoster = "MainPizza.png",
                 ImageUrl = "Pizza.png"
                },
                new Category(){
                 CategoryID = 6,
                 CategoryName = "Birre e Vini",
                 CategoryPoster = "MainPizza.png",
                 ImageUrl = "Pizza.png"
                }
            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl

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

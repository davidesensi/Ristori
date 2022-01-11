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
                    Name = "Suppli classico",
                    Description ="Suppli con riso, pomodoro, mozzarella impanato e fritto",
                    Price = 1
                },
                new Product
                {
                    ProductID = 2,
                    CategoryID = 1,
                    Name = "Suppli amatriciana",
                    Description ="Suppli con riso, pomodoro, guanciale, pecorino impanato e fritto",
                    Price = 3
                },
                new Product
                {
                    ProductID = 3,
                    CategoryID = 1,
                    Name = "Suppli carbonara",
                    Description ="Suppli con rigatone, uovo, guanciale, pecorino impanato e fritto",
                    Price = 3
                },
                new Product
                {
                    ProductID = 4,
                    CategoryID = 1,
                    Name = "Patatine Fritte",
                    Description ="Patate fritte",
                    Price = 3
                },
                new Product
                {
                    ProductID = 5,
                    CategoryID = 1,
                    Name = "Olive all'ascolana",
                    Description ="Oliva con misto carne impanata e fritta",
                    Price = 3
                },
                new Product
                {
                    ProductID = 6,
                    CategoryID = 1,
                    Name = "Mozzarelline",
                    Description ="Bocconcino di mozzarella impanato e fritto",
                    Price = 3
                },
                new Product
                {
                    ProductID = 7,
                    CategoryID = 2,
                    Name = "Margherita",
                    Description ="Pizza con pomodoro e mozzarella",
                    Price = 6
                },
                new Product
                {
                    ProductID = 8,
                    CategoryID = 2,
                    Name = "Bufalina",
                    Description ="Pizza con pomodoro e mozzarella di bufala",
                    Price = 6
                },
                new Product
                {
                    ProductID = 9,
                    CategoryID = 2,
                    Name = "Piccante",
                    Description ="Pizza con pomodoro, mozzarella e salame piccante ",
                    Price = 6
                },
                new Product
                {
                    ProductID = 10,
                    CategoryID = 2,
                    Name = "Capricciosa",
                    Description ="Pizza con pomodoro, mozzarella, funghi, carciofi, olive nere",
                    Price = 6
                },
                new Product
                {
                    ProductID = 11,
                    CategoryID = 3,
                    Name = "Topolino",
                    Description ="Pizza con mozzarella, prosciutto cotto e mais",
                    Price = 6
                },
                new Product
                {
                    ProductID = 12,
                    CategoryID = 3,
                    Name = "4 Formaggi",
                    Description ="Pizza con mozzarella, pecorino, taleggio e gorgonzola",
                    Price = 6
                },
                new Product
                {
                    ProductID = 13,
                    CategoryID = 3,
                    Name = "Raffinata",
                    Description ="Pizza con brasaola, rucola, pomodorini e grana",
                    Price = 6
                },
                new Product
                {
                    ProductID = 14,
                    CategoryID = 4,
                    Name = "Tiramisu",
                    Description ="Dolce con mascarpone, biscotti bagnati nel caffe e cacao sopra",
                    Price = 4
                },
                new Product
                {
                    ProductID = 15,
                    CategoryID = 4,
                    Name = "Caramello",
                    Description ="Panna cotta con caramello",
                    Price = 4
                },
                new Product
                {
                    ProductID = 16,
                    CategoryID = 4,
                    Name = "Cioccalata",
                    Description ="Panna cotta con cioccolata",
                    Price = 4
                },
                new Product
                {
                    ProductID = 17,
                    CategoryID = 4,
                    Name = "Frutti Rossi",
                    Description ="Panna cotta con frutti rossi",
                    Price = 4
                },
                new Product
                {
                    ProductID = 18,
                    CategoryID = 5,
                    Name = "Coca Cola M",
                    Description ="Coca Cola 33cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 19,
                    CategoryID = 5,
                    Name = "Coca Cola XL",
                    Description ="Coca Cola 50cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 20,
                    CategoryID = 5,
                    Name = "Fanta M",
                    Description ="Fanta 33cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 21,
                    CategoryID = 5,
                    Name = "Fanta XL",
                    Description ="Fanta 50cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 22,
                    CategoryID = 5,
                    Name = "Sprite M",
                    Description ="Sprite 33cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 23,
                    CategoryID = 5,
                    Name = "Sprite XL",
                    Description ="Sprite 50cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 24,
                    CategoryID = 5,
                    Name = "Acqua M",
                    Description ="Acqua 50cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 25,
                    CategoryID = 5,
                    Name = "Acqua XL",
                    Description ="Acqua 150cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 26,
                    CategoryID = 6,
                    Name = "Ichnusa M",
                    Description ="Birra Bionda 33cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 27,
                    CategoryID = 6,
                    Name = "Ichnusa XL",
                    Description ="Birra Bionda 50cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 28,
                    CategoryID = 6,
                    Name = "Hoegaarden M",
                    Description ="Birra Bianca 33cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 29,
                    CategoryID = 6,
                    Name = "Hoegaarden XL",
                    Description ="Birra Bianca 50cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 30,
                    CategoryID = 6,
                    Name = "Passerina",
                    Description ="Vino bianco fermo fruttato Marche 75cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 31,
                    CategoryID = 6,
                    Name = "Pecorino",
                    Description ="Vino bianco fermo deciso Marche 75cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 32,
                    CategoryID = 6,
                    Name = "Verdicchio",
                    Description ="Vino bianco spumantizzato fruttato Marche 75cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 33,
                    CategoryID = 6,
                    Name = "Montepulciano d'Abruzzo",
                    Description ="Vino rosso corposo Abruzzo 75cl",
                    Price = 4
                },
                new Product
                {
                    ProductID = 34,
                    CategoryID = 6,
                    Name = "Rosso Piceno",
                    Description ="Vino rosso morbido Marche 75cl",
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

using Ristori.Models;
using Ristori.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ristori.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShellView : Shell
    {
        public ShellView()
        {
            InitializeComponent();

            Categories = new ObservableCollection<Category>();

            GetCategories();
        }

        public ObservableCollection<Category> Categories { get; set; }

        private async void GetCategories()
        {

            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var category in data)
            {
                Categories.Add(category);
            }
        }
    }
}
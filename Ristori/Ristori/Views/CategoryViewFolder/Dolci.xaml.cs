using Ristori.Models;
using Ristori.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ristori.Views.CategoryViewFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dolci : ContentPage
    {

        CategoryViewModel cvm;
        public Dolci()
        {
            InitializeComponent();
            int ID = new int();
            ID = 4;
            cvm = new CategoryViewModel(ID);
            this.BindingContext = cvm;
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as Product;
            if (selectedProduct == null)
                return;
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
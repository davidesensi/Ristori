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
    public partial class PizzeBianche : ContentPage
    {

        CategoryViewModel cvm;
        public PizzeBianche()
        {
            InitializeComponent();
            int ID = new int();
            ID = 3;
            cvm = new CategoryViewModel(ID);
            this.BindingContext = cvm;
        }

        void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as Product;
            if (selectedProduct == null)
                return;
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
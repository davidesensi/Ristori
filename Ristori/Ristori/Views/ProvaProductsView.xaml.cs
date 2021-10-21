using Ristori.Models;
using Ristori.ViewModels;
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
    public partial class ProvaProductsView : ContentPage
    {
        public ProvaProductsViewModel ppvm;

        public ProvaProductsView()
        {
            InitializeComponent();

            ppvm = new ProvaProductsViewModel();


            this.BindingContext = ppvm;
        }

        async void ProvaProductView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as Product;
            if (selectedProduct == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailsView(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
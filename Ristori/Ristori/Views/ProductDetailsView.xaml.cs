using Ristori.Models;
using Ristori.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ristori.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsView : ContentPage
    {
        ProductDetailsViewModel pvm;
        public ProductDetailsView(Product product)
        {
            InitializeComponent();
            pvm = new ProductDetailsViewModel(product);
            this.BindingContext = pvm;
        }

        private async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
             await Navigation.PopAsync();
        }
    }
}
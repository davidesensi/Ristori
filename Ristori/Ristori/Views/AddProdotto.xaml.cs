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
    public partial class AddProdotto : ContentPage
    {
        public AddProdotto()
        {
            InitializeComponent();
            this.BindingContext = new ProductsViewModel();
            base.OnAppearing();
        }
        protected override void OnAppearing()
        {
            this.BindingContext = new ProductsViewModel();
            base.OnAppearing();
        }
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
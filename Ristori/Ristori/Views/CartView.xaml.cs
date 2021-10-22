using Ristori.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ristori.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartView : ContentPage
    {
        
        public CartView()
        {
            InitializeComponent();
            this.BindingContext = new CartViewModel();
            base.OnAppearing();
        }
        protected override void OnAppearing()
        {
            this.BindingContext = new CartViewModel();
            base.OnAppearing();
        }
        private async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
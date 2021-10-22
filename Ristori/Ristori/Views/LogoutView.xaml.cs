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
    public partial class LogoutView : ContentPage
    {
        public LogoutView()
        {
            InitializeComponent();
            this.BindingContext = new LogoutViewModel();
            base.OnAppearing();
        }
        protected override void OnAppearing()
        {
            this.BindingContext = new LogoutViewModel();
            base.OnAppearing();
        }
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
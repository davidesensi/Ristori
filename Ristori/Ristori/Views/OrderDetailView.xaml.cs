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
    public partial class OrderDetailView : ContentPage
    {
        public OrderDetailView(string id)
        {
            InitializeComponent();
            LabelName.Text = "Ciao " + Preferences.Get("Username", "Guest") + ",";
            LabelOrderId.Text = id;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ShellView());
        }
    }
}
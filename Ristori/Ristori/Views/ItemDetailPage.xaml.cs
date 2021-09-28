using Ristori.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Ristori.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
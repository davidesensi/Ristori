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
    public partial class OrderHistoryViewDeliveryNow : ContentPage
    {
        public OrderHistoryViewDeliveryNow()
        {
            InitializeComponent();
            BindingContext = new OrderHistoryViewModel();
        }

        protected override void OnAppearing()
        {
            BindingContext = new OrderHistoryViewModel();
            base.OnAppearing();
        }
    }
}
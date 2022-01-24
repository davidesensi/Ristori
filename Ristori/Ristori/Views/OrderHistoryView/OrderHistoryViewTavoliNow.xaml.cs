using Ristori.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ristori.Views.OrderHistoryView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderHistoryViewTavoliNow : ContentPage
    {
        public OrderHistoryViewTavoliNow()
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
using Ristori.Models;
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
        public CartViewModel cvm;
        public CartView()
        {
            InitializeComponent();
            cvm = new CartViewModel();
            this.BindingContext = cvm;
            base.OnAppearing();
        }
        protected override void OnAppearing()
        {
            this.cvm = new CartViewModel();
            this.BindingContext = cvm;
            base.OnAppearing();
        }
        
        
    }
}
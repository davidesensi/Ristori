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
    public partial class NewProductView : ContentPage
    {

        public NewProductViewModel npvm;
        public NewProductView()
        {
            InitializeComponent();
            npvm = new NewProductViewModel();
            BindingContext = npvm;
            base.OnAppearing();
        }

        protected override void OnAppearing()
        {
            this.npvm = new NewProductViewModel();
            this.BindingContext = npvm;
            base.OnAppearing();
        }
    }
}
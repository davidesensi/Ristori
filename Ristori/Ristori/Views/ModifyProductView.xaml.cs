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
    public partial class ModifyProductView : ContentPage
    {
        public ModifyProductViewModel mpvm;
        public ModifyProductView()
        {
            InitializeComponent();
            mpvm = new ModifyProductViewModel();
            BindingContext = mpvm;
            base.OnAppearing();
        }

        protected override void OnAppearing()
        {
            this.mpvm = new ModifyProductViewModel();
            this.BindingContext = mpvm;
            base.OnAppearing();
        }
    }
}
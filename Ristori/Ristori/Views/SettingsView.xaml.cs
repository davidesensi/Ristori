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
    public partial class SettingsView : ContentPage
    {
        public SettingsViewModel svm;
        public SettingsView()
        {
            InitializeComponent();
            svm = new SettingsViewModel();
            this.BindingContext = svm;
            base.OnAppearing();
        }

        protected override void OnAppearing()
        {
            svm = new SettingsViewModel();
            this.BindingContext = svm;
            base.OnAppearing();
        }

        
    }
}
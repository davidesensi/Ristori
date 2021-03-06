using Ristori.Helpers;
using Ristori.Services;
using Ristori.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ristori
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            var cct = new CreateCartTable();
            cct.CreateTable();

            //MainPage = new LoginView();
            //MainPage = new NavigationPage(new SettingsPage());
            string oname = Preferences.Get("Username", String.Empty);
            if(String.IsNullOrEmpty(oname))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new ShellView();
                //MainPage = new ProductsView();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

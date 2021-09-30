using Ristori.Services;
using Ristori.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ristori
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //MainPage = new LoginView();
            MainPage = new NavigationPage(new SettingsPage());
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

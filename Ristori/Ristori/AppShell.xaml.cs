using Ristori.ViewModels;
using Ristori.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ristori
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}

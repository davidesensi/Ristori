using Ristori.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ristori.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command LogoutCommand { get; set; }

        public SettingsViewModel()
        {
            LogoutCommand = new Command(async () => await  LogoutViewCall());
        }

        private async Task LogoutViewCall()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

    }
}

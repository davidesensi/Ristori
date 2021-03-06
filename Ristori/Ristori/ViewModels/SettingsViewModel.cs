using Ristori.Helpers;
using Ristori.Views;
using Ristori.Views.OrderHistoryView;
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
        public Command NewProductCommand { get; set; }
        public Command ModifyProductCommand { get; set; }
        public Command AllDeliveryCommand { get; set; }
        public Command AllTavoloCommand { get; set; }

        public SettingsViewModel()
        {
            LogoutCommand = new Command(async () => await LogoutViewCall());
            NewProductCommand = new Command(async () => await NewProductCall());
            ModifyProductCommand = new Command(async () => await ModifyProductCall());
            AllDeliveryCommand = new Command(async () => await AllDeliveryCall());
            AllTavoloCommand = new Command(async () => await AllTavoloCall());
        }

        private async Task NewProductCall()
        {
            await Shell.Current.Navigation.PushAsync(new NewProductView());
        }

        private async Task ModifyProductCall()
        {
            await Shell.Current.Navigation.PushAsync(new ModifyProductView());
        }

        private async Task LogoutViewCall()
        {
            await Shell.Current.Navigation.PushAsync(new LogoutView());
        }

        private async Task AllDeliveryCall()
        {
            await Shell.Current.Navigation.PushAsync(new OrderHistoryViewDeliveryAll());
        }

        private async Task AllTavoloCall()
        {
            await Shell.Current.Navigation.PushAsync(new OrderHistoryViewTavoliAll());
        }
    }
}

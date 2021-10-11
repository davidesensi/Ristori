using Ristori.Services;
using Ristori.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ristori.ViewModels
{
    public class LogoutViewModel : BaseViewModel
    {
        private int _OperatorCartItemsCount;
        public int OperatorCartItemsCount
        {
            set
            {
                _OperatorCartItemsCount = value;
                OnPropertyChanged();
            }
            get
            {
                return _OperatorCartItemsCount;
            }
        }

        private bool _IsCartExist;
        public bool IsCartExist
        {
            set
            {
                _IsCartExist = value;
                OnPropertyChanged();
            }
            get
            {
                return _IsCartExist;
            }
        }


        public Command LogoutCommand { get; set; }
        public Command GoToCartCommand { get; set; }
        public LogoutViewModel()
        {
            OperatorCartItemsCount = new CartProductService().GetOperatorCartCount();

            IsCartExist = (OperatorCartItemsCount > 0) ? true : false;

            LogoutCommand = new Command(async () => await LogoutOperatorAsync());
            GoToCartCommand = new Command(async () => await GoToCartAsync());

        }

        private async Task GoToCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async Task LogoutOperatorAsync()
        {
            var cis = new CartProductService();
            cis.RemoveProductsFromCart();
            Preferences.Remove("Username");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());

        }
    }
}

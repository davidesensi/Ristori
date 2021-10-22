using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Ristori.ViewModels
{
    public class BaseViewModel : BindableObject, INotifyPropertyChanged
    {
        public Command HomeCommand { get; set; }

        

        
    }
}

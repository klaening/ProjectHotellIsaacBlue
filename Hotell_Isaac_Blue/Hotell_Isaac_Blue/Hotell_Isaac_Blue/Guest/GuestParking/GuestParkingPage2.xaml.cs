using System;
using Hotell_Isaac_Blue.Guest;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue.Guest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestParkingPage2 : ContentPage
    {
        public GuestParkingPage2()
        {
            InitializeComponent();
        }

        private void continueParking_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestParkingPage3());
        }

    }
}
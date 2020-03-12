using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestMainPage : ContentPage
    {
        public GuestMainPage()
        {
            InitializeComponent();
        }

        private void BookingBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBookingMainPage());
        }

        private void InfoBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestInfoPage());
        }

        private void BreakfastBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBreakfastPage());
        }

        private void ParkingBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestParkingPage());
        }
    }
}
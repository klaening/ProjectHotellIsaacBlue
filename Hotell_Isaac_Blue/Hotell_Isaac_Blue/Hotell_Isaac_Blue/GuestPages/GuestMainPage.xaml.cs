using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hotell_Isaac_Blue.Tables;
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
            AddTapGestures();
        }

        private void AddTapGestures()
        {
            var tapBookingsFrame = new TapGestureRecognizer();
            tapBookingsFrame.Tapped += BookingsFrame_Tapped;
            BookingsFrame.GestureRecognizers.Add(tapBookingsFrame);

            var tapInfoFrame = new TapGestureRecognizer();
            tapInfoFrame.Tapped += InfoFrame_Tapped;
            InfoFrame.GestureRecognizers.Add(tapInfoFrame);

            var tapBreakfastFrame = new TapGestureRecognizer();
            tapBreakfastFrame.Tapped += BreakfastFrame_Tapped;
            BreakfastFrame.GestureRecognizers.Add(tapBreakfastFrame);

            var tapParkingFrame = new TapGestureRecognizer();
            tapParkingFrame.Tapped += ParkingFrame_Tapped;
            ParkingFrame.GestureRecognizers.Add(tapParkingFrame);
        }

        private void ParkingFrame_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestParkingPage());
        }

        private void BreakfastFrame_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBreakfastPage());
        }

        private void InfoFrame_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestInfoPage());
        }

        private void BookingsFrame_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBookingMainPage());
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

        private void MyProfileBtn_Clicked(object sender, EventArgs e)
        {
            if (MyProfileFrame.IsVisible == true)
            {
                MyProfileFrame.IsVisible = false;
            }
            else if (MyProfileFrame.IsVisible == false)
            {
                MyProfileFrame.IsVisible = true;
            }
        }

        private async void LogOutBtn_Clicked(object sender, EventArgs e)
        {

            var logOut = await DisplayAlert("Logging out!","Are you sure you want to log out?", "Yes", "No");
            if (logOut)
            {
                ActiveUser.Account = null;
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}
using Hotell_Isaac_Blue.Model;
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
        public Accounts account { get; set; }

        public GuestMainPage()
        {
            InitializeComponent();
            AddTapGestures();
        }

        public GuestMainPage(Accounts user)
        {
            InitializeComponent();

            account = new Accounts()
            {
                ID = user.ID,
                UserName = user.UserName,
                Password = user.Password
            };

            //var account = new Accounts();
            //account.UserName = user.UserName;
            //account.Password = user.Password;

            this.BindingContext = account;

            //UserName = user.UserName;
            //UserText.T ext = "Logged in as " + user.UserName;
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
    }
}
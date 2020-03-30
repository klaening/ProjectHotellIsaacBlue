using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestBookingThirdPage : ContentPage
    {
        public GuestBookingThirdPage()
        {
            InitializeComponent();
        }

        private void confirmBooking_Clicked(object sender, EventArgs e)
        {

            //await DisplayAlert("Alert", "Successfully", "OK");
            Navigation.PushAsync(new CustomerRegistrationPage());

        }
    }
}
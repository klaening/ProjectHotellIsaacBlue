using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.APIServices;
using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestBookingMainPage : ContentPage
    {
        public GuestBookingMainPage()
        {
            InitializeComponent();
            GetBookings();
            if(ActiveBooking.Booking.ID != null)
            {
                BookingDetails();
            }
            
        }

        

        private async void GetBookings()
        {
            var path = "bookings/";

            string[] source = new string[] { Convert.ToString(ActiveUser.Account.CustomersID) };

            var response = Services.GetService(path, source);
            string result = await response.Content.ReadAsStringAsync();

            var activeBooking = JsonConvert.DeserializeObject<Bookings>(result);

            ActiveBooking.Booking = activeBooking;
        }

        
        public void BookingDetails()
        {
            bookingNr.Text = Convert.ToString(ActiveBooking.Booking.ID);
            startDate.Text = Convert.ToString(ActiveBooking.Booking.STARTDATE);
            endDate.Text = Convert.ToString(ActiveBooking.Booking.ENDDATE);
        }

        private void NewBooking_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBookingSecondPage());
        }
    }
}
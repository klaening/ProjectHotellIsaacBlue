using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.APIServices;
using Hotell_Isaac_Blue.Helpers;
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
            if(ActiveUser.Account.CustomersID != null)
            {
                GetCustomerBookings();
            }
        }

        private async void GetCustomerBookings()
        {
            var path = "bookings/";

            string source = "customer/" + ActiveUser.Account.CustomersID.ToString() + "/end=" + DateTime.Now.ToString("yyyy-MM-dd");

            var response = Services.GetRequest(path, source);
            string result = await response.Content.ReadAsStringAsync();

            var customerBookings = JsonConvert.DeserializeObject<List<Bookings>>(result);

            foreach (var booking in customerBookings)
            {
                CustomFrame frame = new CustomFrame(booking);
                
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    ActiveBooking.Booking.UpdateBookingInfo(frame.BookingNo);
                    Navigation.PushAsync(new GuestBookingThirdPage());
                };

                frame.GestureRecognizers.Add(tapGestureRecognizer);

                bookingStack.Children.Add(frame);
            }
        }

        private void NewBooking_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBookingSecondPage());
        }
    }
}
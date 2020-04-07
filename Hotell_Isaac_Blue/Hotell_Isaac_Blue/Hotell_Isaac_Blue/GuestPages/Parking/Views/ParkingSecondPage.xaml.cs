using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue.GuestPages.Parking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParkingSecondPage : ContentPage
    {
        public ParkingSecondPage()
        {
            InitializeComponent();
            labelStartDateReview.Text = ActiveBooking.Booking.STARTDATE.ToString();
            labelEndDateReview.Text = ActiveBooking.Booking.ENDDATE.ToString();
            labelBookingNoReview.Text = ActiveBooking.Booking.ID.ToString();
            if (ActiveBooking.Booking.PARKING == false)
            {
                BookParking.Text = "Book!";
                ConfirmParking.Text = "Want to add parking to your booking?";
            }
            else
            {
                BookParking.Text = "UnBook!";
                ConfirmParking.Text = "Want to remove your parking booking?";
            }
        }

        private async void BookParking_Clicked(object sender, EventArgs e)
        {
            string key = ActiveBooking.Booking.ID.ToString();
            string path = "bookings/";

            var response = APIServices.Services.GetRequest(path, key);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                ActiveBooking.Booking = JsonConvert.DeserializeObject<Bookings>(result);
                ActiveBooking.RoomID = 1; // SKALL TAS BORT NÄR MICKE FIXAT
                await DisplayAlert("GLÖM EJ", "Ta bort ROOMID på BreakfastsecondPage!", "jaja ok");


                if (ActiveBooking.Booking.PARKING == false)
                {
                    await DisplayAlert("PARKING", "Added Parking", "ok");
                    ActiveBooking.Booking.PARKING = true;
                    await APIServices.Services.PutRequestAsync(path, ActiveBooking.Booking);
                    await Navigation.PushAsync(new GuestBookingThirdPage());
                }
                else
                {
                    await DisplayAlert("PARKING", "UnBooked Parking", "ok");
                    ActiveBooking.Booking.PARKING = false;
                    await APIServices.Services.PutRequestAsync(path, ActiveBooking.Booking);
                    await Navigation.PushAsync(new GuestBookingThirdPage());
                }

            }
            else
            {
                await DisplayAlert("Error!", "Invalid bookingNo", "ok");
            }
        }
    }
}
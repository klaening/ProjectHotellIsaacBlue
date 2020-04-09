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
        public int ParkingTotalCost { get; set; }
        public ParkingSecondPage()
        {
            InitializeComponent();
            ParkingTotalCost = 80 * Helpers.Helpers.CalculateTotalDays(ActiveBooking.Booking.STARTDATE, ActiveBooking.Booking.ENDDATE);
        // Hämtar och sätter värden på labels.
            labelStartDateReview.Text = ActiveBooking.Booking.STARTDATE.ToString();
            labelEndDateReview.Text = ActiveBooking.Booking.ENDDATE.ToString();
            labelBookingNoReview.Text = ActiveBooking.Booking.ID.ToString();
            labelParkingTotalCost.Text = ParkingTotalCost.ToString();

            if (ActiveBooking.Booking.PARKING == false)
            {
                // Sätter värdet på Knappen till Book! om Parking = false.
                BookParking.Text = "Book!";
                ConfirmParking.Text = "Want to add parking to your booking?";
            }
            else
            {
                // Sätter värdet på Knappen till UnBook! om Parking = true.
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

                if (ActiveBooking.Booking.PARKING == false)
                {                   
                    ActiveBooking.Booking.PARKING = true;                   
                    await DisplayAlert("PARKING", "Added Parking", "ok");                    
                }
                else
                {                   
                    ActiveBooking.Booking.PARKING = false;
                    await DisplayAlert("PARKING", "UnBooked Parking", "ok");
                }
                await APIServices.Services.PutRequestAsync(path, ActiveBooking.Booking);
                await Navigation.PushAsync(new GuestBookingThirdPage());
            }
            else
            {
                await DisplayAlert("Error!", "Invalid bookingNo", "ok");
            }
        }
    }
}
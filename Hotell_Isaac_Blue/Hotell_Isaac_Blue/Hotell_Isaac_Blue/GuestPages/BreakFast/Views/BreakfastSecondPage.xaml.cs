using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue.GuestPages.BreakFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreakfastSecondPage : ContentPage
    {
        public int BreakfastTotalCost { get; set; }
        public BreakfastSecondPage()
        {
            InitializeComponent();
            BreakfastTotalCost = 80 * Helpers.Helpers.CalculateTotalDays(ActiveBooking.Booking.STARTDATE, ActiveBooking.Booking.ENDDATE);
            labelStartDateReview.Text = ActiveBooking.Booking.STARTDATE.ToString();
            labelEndDateReview.Text = ActiveBooking.Booking.ENDDATE.ToString();
            labelBookingNoReview.Text = ActiveBooking.Booking.ID.ToString();
            labelBreakfastTotalCost.Text = BreakfastTotalCost.ToString();

            if (ActiveBooking.Booking.BREAKFAST == false)
            {
                BookBreakfast.Text = "Book!";
            }
            else
            {
                BookBreakfast.Text = "UnBook!";
            }
        }


        private async void BookBreakfast_Clicked(object sender, EventArgs e)
        {

            string key = ActiveBooking.Booking.ID.ToString();
            string path = "bookings/";

            var response = APIServices.Services.GetRequest(path, key);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                ActiveBooking.Booking = JsonConvert.DeserializeObject<Bookings>(result);
                ActiveBooking.RoomID = 1; // SKALL TAS BORT NÄR MICKE FIXAT

                if (ActiveBooking.Booking.BREAKFAST == false)
                {
                    ActiveBooking.Booking.BREAKFAST = true;                     
                    await DisplayAlert("BREAKFAST", "Added Breakfast", "ok");                   
                }
                else
                {
                    ActiveBooking.Booking.BREAKFAST = false;                   
                    await DisplayAlert("BREAKFAST", "UnBooked Breakfast", "ok");                   
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
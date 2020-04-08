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
        public BreakfastSecondPage()
        {
            InitializeComponent();
            labelStartDateReview.Text = ActiveBooking.Booking.STARTDATE.ToString();
            labelEndDateReview.Text = ActiveBooking.Booking.ENDDATE.ToString();
            labelBookingNoReview.Text = ActiveBooking.Booking.ID.ToString();
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
                await DisplayAlert("GLÖM EJ", "Ta bort ROOMID på BreakfastsecondPage!", "jaja ok");


                if (ActiveBooking.Booking.BREAKFAST == false)
                {
                    ActiveBooking.Booking.BREAKFAST = true;
                    await DisplayAlert("BREAKFAST", "Added Breakfast", "ok");
                    await Navigation.PushAsync(new GuestBookingThirdPage());
                }
                else
                {
                    await DisplayAlert("BREAKFAST", "UnBooked Breakfast", "ok");
                    ActiveBooking.Booking.BREAKFAST = false;
                    await Navigation.PushAsync(new GuestBookingThirdPage());
                }
                await APIServices.Services.PutRequestAsync(path, ActiveBooking.Booking);
            }
            else
            {
                await DisplayAlert("Error!", "Invalid bookingNo", "ok");
            }

        }
    }
}
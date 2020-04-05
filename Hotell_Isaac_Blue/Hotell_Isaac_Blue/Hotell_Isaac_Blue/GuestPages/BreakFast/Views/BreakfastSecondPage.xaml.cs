using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.GuestPages.BreakFast.Models;
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
            labelBookingNoReview.Text = BreakfastModel.BookingNo;
        }

        
        private async void BookBreakfast_Clicked(object sender, EventArgs e)
        {
            string[] key = new string[] { BreakfastModel.BookingNo };
            string path = "bookings/";

            var response = APIServices.Services.GetRequest(path, key);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var testBooking = JsonConvert.DeserializeObject<Bookings>(result);
                
                await DisplayAlert("Success!", "Added Breakfast", "ok");


                if (testBooking.BREAKFAST == false)
                {
                    testBooking.BREAKFAST = true;
                    await APIServices.Services.PutRequestAsync(path, testBooking);

                }
                if (testBooking.BREAKFAST == true) 
                {
                    testBooking.BREAKFAST = false;
                    await APIServices.Services.PutRequestAsync(path, testBooking);
                }
            }
            else
            {
                await DisplayAlert("Error!", "Invalid bookingNo", "ok");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.GuestPages.BreakFast.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Hotell_Isaac_Blue.Tables;
using System.Diagnostics;

namespace Hotell_Isaac_Blue.GuestPages.BreakFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreakfastFirstPage : ContentPage
    {
        public BreakfastFirstPage()
        {           
            InitializeComponent();           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string path = "bookings/";

            string[] key = new string[] { BookingEntry.Text };

            var response = APIServices.Services.GetService(path, key);
            string result = await response.Content.ReadAsStringAsync();
            var testBooking = JsonConvert.DeserializeObject<Bookings>(result);
            
            if(response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success!", "Added Breakfast", "ok");
                ActiveBooking.Booking = testBooking;
                ActiveBooking.Booking.BREAKFAST = false;
                //Update webapi!
                
                
            }
            else
            {
                await DisplayAlert("Error!", "Deleted Request", "ok");
            }
           
        }
    }
}
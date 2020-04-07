using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue.GuestPages.Parking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParkingFirstPage : ContentPage
    {
        public ParkingFirstPage()
        {
            InitializeComponent();
        }

        private async void Parkingspot_Clicked(object sender, EventArgs e)
        {
            try
            {
                string key = BookingParkEntry.Text;
                string path = "bookings/";

                var response = APIServices.Services.GetRequest(path, key);
                string result = await response.Content.ReadAsStringAsync();

                ActiveBooking.Booking = JsonConvert.DeserializeObject<Bookings>(result);

                await Navigation.PushAsync(new ParkingSecondPage());
            }
            catch (Exception)
            {

                await DisplayAlert("Error", "Please Enter a valid Booking Number", "ok");
            }
            
        }
    }
}
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
                string path = "bookings/" + BookingParkEntry.Text + "/";
                string key = "customer/" + ActiveUser.Account.CustomersID;

                var response = APIServices.Services.GetRequest(path, key); // Hämtar ett request och sparar i varibel response
                string result = await response.Content.ReadAsStringAsync(); // Läser av värdet och sparar i variabel result

                ActiveBooking.Booking = JsonConvert.DeserializeObject<Bookings>(result); // Deserialize json till ett object (ActiveBooking.Booking)

                await Navigation.PushAsync(new ParkingSecondPage());
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Please Enter a valid Booking Number", "ok");
            }
            
        }
    }
}
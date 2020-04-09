
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Hotell_Isaac_Blue.Models;
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

        public async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string path = "bookings/" + BookingEntry.Text + "/";
                string key = "customer/" + ActiveUser.Account.CustomersID;
                
               

                var response = APIServices.Services.GetRequest(path, key);
                string result = await response.Content.ReadAsStringAsync();
                ActiveBooking.Booking = JsonConvert.DeserializeObject<Bookings>(result);
                await Navigation.PushAsync(new BreakfastSecondPage());
            }
            catch (Exception)
            {

                await DisplayAlert("Error", "Please Enter a valid Booking Number", "ok");
            }
            
        }
 
    }
}
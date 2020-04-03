
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
            

            string[] key = new string[] { BookingEntry.Text };
            string path = "bookings/";

            var response = APIServices.Services.GetService(path, key);
            string result = await response.Content.ReadAsStringAsync();
            var testBooking = JsonConvert.DeserializeObject<Bookings>(result);

            

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success!", "Added Breakfast", "ok");

                testBooking.BREAKFAST = false;
                await APIServices.Services.PutServiceAsync(testBooking,path + key[0] +"/");
             
            }
            else
            {
                await DisplayAlert("Error!", "Deleted Request", "ok");
            }
           
        }
    }
}
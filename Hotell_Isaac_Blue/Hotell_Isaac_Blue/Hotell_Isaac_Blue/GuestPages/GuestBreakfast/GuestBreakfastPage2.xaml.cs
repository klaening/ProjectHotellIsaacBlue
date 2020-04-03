using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue.Guest.GuestBreakfast
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestBreakfastPage2 : ContentPage
    {
        public GuestBreakfastPage2()
        {
            InitializeComponent();
        }

        private async void Breakfast_Continue_Clicked(object sender, EventArgs e)
        {
            var path = "bookings/";
            var bookingNo = new string[] { BreakfastEntry.Text };

            var response = APIServices.Services.GetRequest(path, bookingNo);
            string result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Bookings updatedBooking = JsonConvert.DeserializeObject<Bookings>(result);

                if (!updatedBooking.BREAKFAST)
                    updatedBooking.BREAKFAST = true;
                else
                    updatedBooking.BREAKFAST = false;

                await APIServices.Services.PutRequestAsync(path, updatedBooking);
            }


            await Navigation.PushAsync(new GuestBreakfastPage3());
        }

        private void FirstPage_Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestMainPage());
        }

        private void Contact_Us_Page_Clicked(object sender, EventArgs e)
        {
            // Redirect to Contact Page.
        }

        private void MySettings_Clicked(object sender, EventArgs e)
        {
            // Redirect to users own settingsPage.
        }
    }
}
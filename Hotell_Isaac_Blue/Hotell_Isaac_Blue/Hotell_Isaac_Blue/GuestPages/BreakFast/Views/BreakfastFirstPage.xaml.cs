
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.GuestPages.BreakFast.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

namespace Hotell_Isaac_Blue.GuestPages.BreakFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreakfastFirstPage : ContentPage
    {
        public BreakfastFirstPage()
        {           
            InitializeComponent();           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //string path = "bookings/";

            //string[] key = new string[] { BookingEntry.Text };

            //var response = APIServices.Services.

            BreakfastModel.BookingNo = BookingEntry.Text;
            var client = new HttpClient();
            var response = client.GetAsync("https://hotellisaacbluewebapi.azurewebsites.net/api/bookings/" + BreakfastModel.BookingNo);

            string jsonData = string.Empty;

            if(response.Result.IsSuccessStatusCode)
            {
                
            }
           
        }
    }
}
﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hotell_Isaac_Blue;
using System.Threading.Tasks;
using System.Collections.Generic;
using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestBookingThirdPage : ContentPage
    {
        DateTime startDate = ActiveBooking.Booking.STARTDATE;
        DateTime endDate = ActiveBooking.Booking.ENDDATE;
        RoomTypes roomType = null;
        public GuestBookingThirdPage()
        {
            //FUUUUUUUUL KOOOOOOOOOD!!!!!!!
            InitializeComponent();

            GetRoomType(ActiveBooking.RoomID);

            ReviewNameLabel.Text = $"{ActiveCustomer.Customer.FIRSTNAME} {ActiveCustomer.Customer.LASTNAME}";
            ReviewEmailLabel.Text = ActiveCustomer.Customer.EMAIL;
            ReviewStartDateLabel.Text = ActiveBooking.Booking.STARTDATE.ToString();
            ReviewEndDateLabel.Text = ActiveBooking.Booking.ENDDATE.ToString();
            ReviewTotalDays.Text = Helpers.Helpers.CalculateTotalDays(startDate, endDate).ToString();
            ReviewRoomType.Text = roomType.NAME;
            ReviewPrice.Text = roomType.COST.ToString();
            ReviewExtraBed.Text = ActiveBooking.Booking.EXTRABED.ToString();
            ReviewBreakfast.Text = ActiveBooking.Booking.BREAKFAST.ToString();

            ReviewTotalCostLabel.Text = GetTotalPrice();
        }

        private async void GetRoomType(int roomID)
        {
            var path = "rooms/";
            var source = new string[] { roomID.ToString() };

            var response = APIServices.Services.GetService(path, source);
            string result = await response.Content.ReadAsStringAsync();

            Rooms room = JsonConvert.DeserializeObject<Rooms>(result);

            path = "roomtypes/";
            source[0] = room.ROOMTYPESID.ToString();

            response = APIServices.Services.GetService(path, source);
            result = await response.Content.ReadAsStringAsync();

            roomType = JsonConvert.DeserializeObject<RoomTypes>(result);
        }

        private string GetTotalPrice()
        {
            int totalDays = Helpers.Helpers.CalculateTotalDays(startDate, endDate);

            //Här är felet
            decimal? totalPrice = roomType.COST * totalDays;
            if (ActiveBooking.Booking.BREAKFAST == true)
                totalPrice += 80 * totalDays;
            if (ActiveBooking.Booking.EXTRABED == true)
                totalPrice += 100 * totalDays;

            return totalPrice.ToString();
        }

        private async void confirmBooking_Clicked(object sender, EventArgs e)
        {
            //Skapar ett nytt Booking object och anropar en Service som kallar på Stored Procedure sp_BookingsInsert
            Bookings booking = ActiveBooking.Booking;

            var path = "bookings/";

            var response = APIServices.Services.PostServiceAsync(path, booking);



            //if (ActiveUser.Account.CustomersID != null)
            //{
            //    //hämta värden och sätt de i customers klassen, bokning görs.

            //    var client = new HttpClient();

            //    string findCustomer = Convert.ToString(ActiveUser.Account.CustomersID);

            //    //Returnerar Status kod
            //    var response = await client.GetAsync("https://hotellisaacbluewebapi.azurewebsites.net/api/customers/" + findCustomer + "/");


            //    if (response.ToString().Contains("StatusCode: 200"))
            //    {
            //        //Returnerar json datan för det kontot
            //        string result = await response.Content.ReadAsStringAsync();

            //        //En lista med all aktuell data i json skriptet
            //        List<string> wantedResults = Helpers.Helpers.ExtractData(result);

            //        //Sätter den aktiva användaren till det konto som loggat in
            //        ActiveCustomer.customer = new Customers
            //        {
            //            ID = Convert.ToInt64(wantedResults[0]),
            //            SOCNUMBER = wantedResults[1],
            //            FIRSTNAME = wantedResults[2],
            //            LASTNAME = wantedResults[3],
            //            EMAIL = wantedResults[4],
            //            STREETADRESS = wantedResults[5],
            //            CITY = wantedResults[6],
            //            COUNTRY = wantedResults[7],
            //            ICE = wantedResults[8],
            //            CUSTOMERTYPESID = short.Parse(wantedResults[9]),
            //        };

            //        await Navigation.PushAsync(new GuestMainPage());
            //    }
            //}
            //else
            //{
            //    await Navigation.PushAsync(new CustomerRegistrationPage());
            //}
            ////await DisplayAlert("Alert", "Successfully", "OK");

        }

        private void GetInfo_Clicked(object sender, EventArgs e)
        {

        }
    }
}
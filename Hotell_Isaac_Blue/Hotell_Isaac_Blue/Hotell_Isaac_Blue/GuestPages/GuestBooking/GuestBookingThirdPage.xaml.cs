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
        public GuestBookingThirdPage()
        {
            //FUUUUUUUUL KOOOOOOOOOD!!!!!!!
            InitializeComponent();

            ReviewNameLabel.Text = $"{ActiveCustomer.Customer.FIRSTNAME} {ActiveCustomer.Customer.LASTNAME}";
            ReviewEmailLabel.Text = ActiveCustomer.Customer.EMAIL;
            ReviewStartDateLabel.Text = ActiveBooking.Booking.STARTDATE.ToString();
            ReviewEndDateLabel.Text = ActiveBooking.Booking.ENDDATE.ToString();
            ReviewTotalDays.Text = ActiveBooking.TotalDays.ToString();
            ReviewRoomType.Text = ActiveBooking.RoomType.NAME;
            ReviewPrice.Text = ActiveBooking.RoomType.COST.ToString();
            ReviewExtraBed.Text = ActiveBooking.Booking.EXTRABED.ToString();
            ReviewBreakfast.Text = ActiveBooking.Booking.BREAKFAST.ToString();

            ReviewTotalCostLabel.Text = GetTotalPrice();
        }

        private string GetTotalPrice()
        {
            decimal? totalPrice = ActiveBooking.RoomType.COST * ActiveBooking.TotalDays;
            if (ActiveBooking.Booking.BREAKFAST == true)
                totalPrice += 80 * ActiveBooking.TotalDays;
            if (ActiveBooking.Booking.EXTRABED == true)
                totalPrice += 100 * ActiveBooking.TotalDays;

            return totalPrice.ToString();
        }

        private async void confirmBooking_Clicked(object sender, EventArgs e)
        {
            //Skapar ett nytt Booking object och anropar en Service som kallar på Stored Procedure sp_BookingsInsert


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
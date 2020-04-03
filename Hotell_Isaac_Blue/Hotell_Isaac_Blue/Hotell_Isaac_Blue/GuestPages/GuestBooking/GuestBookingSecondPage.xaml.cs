﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestBookingSecondPage : ContentPage
    {
        DateTime dateMinValue = DateTime.MinValue;
        DateTime startDate;
        DateTime endDate;
        string pickedRoomType = null;
        short guestQty;
        bool extraBed = false;
        bool breakfast = false;
        RoomTypes RoomType = null;
        public GuestBookingSecondPage()
        {
            InitializeComponent();
        }

        private void Result_Btn_Clicked(object sender, EventArgs e)
        {
            if (ActiveUser.Account.CustomersID == null)
                Navigation.PushAsync(new CustomerRegistrationPage());
            else
            {
                pickedRoomType = (string)RoomType_Picker.SelectedItem;
                guestQty = short.Parse(GuestsQty_Picker.SelectedItem.ToString());
                extraBed = Bed_Switch.IsToggled;
                breakfast = Breakfast_Switch.IsToggled;

                ActiveBooking.Booking = new Bookings
                {
                    QTYPERSONS = guestQty,
                    STARTDATE = startDate,
                    ENDDATE = endDate,
                    EXTRABED = extraBed,
                    BREAKFAST = breakfast,
                    CUSTOMERSID = ActiveUser.Account.CustomersID
                };

                GetRoomType();

                //Nånstans ska det göras en check på om det finns ett sådant rum ledigt de datumen

                ActiveBooking.RoomID = RoomType.ID;

                Navigation.PushAsync(new GuestBookingThirdPage());
            }
        }

        /// <summary>
        /// Kanske kan ta bort denna
        /// </summary>
        private async void GetRoomType()
        {
            try
            {
                var path = "roomtypes/";
                var source = new string[] { pickedRoomType };

                var response = APIServices.Services.GetRequest(path, source);
                string result = await response.Content.ReadAsStringAsync();

                //Vi får ett objekt av en RoomTypes som vi vill använda på BookingThirdPage
                RoomType = JsonConvert.DeserializeObject<RoomTypes>(result);

            }
            catch (Exception)
            {   ///////////////////////////////////////////////
                await DisplayAlert("Hej", "Hej", "OK");
                ///////////////////////////////////////////////
            }
        }

        private void DatePickerSD_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime pickedDate = e.NewDate;

            if (pickedDate < DateTime.Now.Date)
            {
                DisplayAlert("Alert", "Start date can not precede today's date", "OK");
            }
            else if (endDate != dateMinValue && pickedDate >= endDate)
            {
                DisplayAlert("Alert", "End date can not precede start date", "OK");
            }
            else
            {
                startDate = e.NewDate;
                (string date, string year) = ReturnDateAndYear(e.NewDate.ToLongDateString());

                SDDateLabel.Text = date;
                SDYearLabel.Text = year;
            }
        }

        private void DatePickerED_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime pickedDate = e.NewDate;

            if (pickedDate <= DateTime.Now.Date)
            {
                DisplayAlert("Alert", "End date can not precede today's date", "OK");
            }
            else if (pickedDate <= startDate)
            {
                DisplayAlert("Alert", "End date can not precede start date", "OK");
            }
            else
            {
                endDate = e.NewDate;
                (string date, string year) = ReturnDateAndYear(e.NewDate.ToLongDateString());

                EDDateLabel.Text = date;
                EDYearLabel.Text = year;
            }
        }

        private (string date, string year) ReturnDateAndYear(string longDate)
        {
            string[] dateSplit = longDate.Split(' ');
            string date = dateSplit[0].Remove(3) + ",";
            
            if (dateSplit[1].Length > 3)
            {
                dateSplit[1] = dateSplit[1].Remove(3);
            }

            dateSplit[2] = dateSplit[2].Remove(dateSplit[2].Length - 1);
            string year = dateSplit[3];

            for (int i = 1; i < 3; i++)
            {
                date += " " + dateSplit[i];
            }

            return (date, year);
        }

        private void SDFrame_Tapped(object sender, EventArgs e)
        {
            DatePickerSD.Focus();
        }

        private void EDFrame_Tapped(object sender, EventArgs e)
        {
            DatePickerED.Focus();
        }

        private void Options_Btn_Clicked(object sender, EventArgs e)
        {
            if (OptionsFrame.IsVisible == false)
            {
                Options_Btn.Text = "-";
                OptionsFrame.IsVisible = true;
            }
            else
            {
                Options_Btn.Text = "+";
                OptionsFrame.IsVisible = false;
            }
        }
    }
}
using System;
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
        //Ta bort?
        RoomTypes RoomType = null;
        public GuestBookingSecondPage()
        {
            InitializeComponent();

            //Vi får ett objekt av en RoomTypes som vi vill använda på BookingThirdPage
            //Göra en get för att se vilka rumstyper som finns?
            //RoomType = JsonConvert.DeserializeObject<RoomTypes>(result)
        }

        private async void Result_Btn_Clicked(object sender, EventArgs e)
        {
            if (ActiveUser.Account.CustomersID == null)
                await Navigation.PushAsync(new CustomerRegistrationPage());
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

                try
                {
                    await GetRoomNo();
                    await Navigation.PushAsync(new GuestBookingThirdPage());
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "No such rooms are available for these dates", "OK");
                }
            }
        }

        private async Task GetRoomNo()
        {
            //Jag vill kolla vilka rum som är lediga mellan två datum med rumstypnummer det som gästen valt

            //Get för att få tag på rumstypsnummer
            string path = "roomtypes/";
            string source = pickedRoomType;

            var response = APIServices.Services.GetRequest(path, source);
            string result = await response.Content.ReadAsStringAsync();

            var roomType = JsonConvert.DeserializeObject<RoomTypes>(result);


            string[] startDateFormat = startDate.GetDateTimeFormats();
            string[] endDateFormat = endDate.GetDateTimeFormats();

            //Nu vill jag göra en get med rumstypnumret och två datum.
            path = $"rooms/roomtype/{roomType.ID}/";
            source = "start=" + startDateFormat[5] + "/end=" + endDateFormat[5];

            response = APIServices.Services.GetRequest(path, source);
            result = await response.Content.ReadAsStringAsync();

            var availableRooms = JsonConvert.DeserializeObject<List<Rooms>>(result);

            if (availableRooms.Count == 0)
                throw new Exception();

            ActiveBooking.RoomID = RandomRoom(availableRooms);
        }

        private short RandomRoom(List<Rooms> rooms)
        {
            Random rnd = new Random();

            int max = rooms.Count;
            int randomRoom = (short)rnd.Next(1, max);

            short roomID = rooms[randomRoom].ID;

            return roomID;
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
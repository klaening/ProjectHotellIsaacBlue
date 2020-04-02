using System;
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
        Customers customerDetails = null;
        public GuestBookingThirdPage()
        {
            //FUUUUUUUUL KOOOOOOOOOD!!!!!!!
            InitializeComponent();

            GetCustomer(ActiveUser.Account.CustomersID.ToString());
            GetRoomType(ActiveBooking.RoomID);

            ReviewNameLabel.Text = $"{customerDetails.FIRSTNAME} {customerDetails.LASTNAME}";
            ReviewEmailLabel.Text = customerDetails.EMAIL;
            ReviewStartDateLabel.Text = ActiveBooking.Booking.STARTDATE.ToString();
            ReviewEndDateLabel.Text = ActiveBooking.Booking.ENDDATE.ToString();
            ReviewTotalDays.Text = Helpers.Helpers.CalculateTotalDays(startDate, endDate).ToString();
            ReviewRoomType.Text = roomType.NAME;
            ReviewPrice.Text = roomType.COST.ToString();
            ReviewExtraBed.Text = ActiveBooking.Booking.EXTRABED.ToString();
            ReviewBreakfast.Text = ActiveBooking.Booking.BREAKFAST.ToString();

            ReviewTotalCostLabel.Text = GetTotalPrice();
        }

        private async void GetCustomer(string id)
        {
            var path = "customers/";

            string[] source = new string[] { id };

            var response = APIServices.Services.GetService(path, source);
            string result = await response.Content.ReadAsStringAsync();

            var activeCustomer = JsonConvert.DeserializeObject<Customers>(result);

            customerDetails = activeCustomer;
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
            ActiveBooking booking = new ActiveBooking();

            var path = "bookings/";

            var response = APIServices.Services.PostServiceAsync(path, booking);
        }
    }
}
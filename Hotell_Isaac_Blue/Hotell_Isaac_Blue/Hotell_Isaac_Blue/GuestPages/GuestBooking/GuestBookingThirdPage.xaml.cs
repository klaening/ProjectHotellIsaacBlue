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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RoomTypes RoomType { get; set; }
        public Customers CustomerDetails { get; set; }
        public GuestBookingThirdPage()
        {
            InitializeComponent();

            if (ActiveUser.Account.CustomersID.HasValue)
            {
                GetCustomer(ActiveUser.Account.CustomersID);
                GetRoomType(ActiveBooking.RoomID);
                StartDate = ActiveBooking.Booking.STARTDATE;
                EndDate = ActiveBooking.Booking.ENDDATE;

                ReviewNameLabel.Text = CustomerDetails.FIRSTNAME + " " + CustomerDetails.LASTNAME;
                ReviewEmailLabel.Text = CustomerDetails.EMAIL;
                ReviewStartDateLabel.Text = ActiveBooking.Booking.STARTDATE.ToString("dd/MM/yyyy");
                ReviewEndDateLabel.Text = ActiveBooking.Booking.ENDDATE.ToString("dd/MM/yyyy");
                ReviewTotalDays.Text = Helpers.Helpers.CalculateTotalDays(StartDate, EndDate).ToString();

                ReviewRoomType.Text = RoomType.NAME;
                ReviewPrice.Text = RoomType.COST.ToString("F");
                ReviewExtraBed.Text = ActiveBooking.Booking.EXTRABED.ToString();
                ReviewBreakfast.Text = ActiveBooking.Booking.BREAKFAST.ToString();
                ReviewParking.Text = ActiveBooking.Booking.PARKING.ToString();

                ReviewTotalCostLabel.Text = GetTotalPrice().ToString("F");
            }
            else
            {
                Navigation.PopAsync();
                GoToRegistrationPage();
            }
        }

        private async void GoToRegistrationPage()
        {
            await DisplayAlert("Not so fast!", "You must register your details to be able to book a room", "OK");
            await Navigation.PushAsync(new CustomerRegistrationPage());
        }

        private async void GetCustomer(long? id)
        {
            string path = "customers/";

            string source = id.ToString();

            var response = APIServices.Services.GetRequest(path, source);
            string result = await response.Content.ReadAsStringAsync();

            CustomerDetails = JsonConvert.DeserializeObject<Customers>(result);
        }

        private async void GetRoomType(short? roomID)
        {
            var path = "rooms/";
            var source = roomID.ToString();

            var response = APIServices.Services.GetRequest(path, source);
            string result = await response.Content.ReadAsStringAsync();

            Rooms room = JsonConvert.DeserializeObject<Rooms>(result);


            path = "roomtypes/";
            source = room.ROOMTYPESID.ToString();

            response = APIServices.Services.GetRequest(path, source);
            result = await response.Content.ReadAsStringAsync();

            RoomType = JsonConvert.DeserializeObject<RoomTypes>(result);
        }

        private decimal GetTotalPrice()
        {
            int totalDays = Helpers.Helpers.CalculateTotalDays(StartDate, EndDate);

            decimal totalPrice = RoomType.COST * totalDays;
            if (ActiveBooking.Booking.BREAKFAST == true)
                totalPrice += 80 * totalDays;
            if (ActiveBooking.Booking.EXTRABED == true)
                totalPrice += 100 * totalDays;
            if (ActiveBooking.Booking.PARKING == true)
                totalPrice += 80 * totalDays;

            return totalPrice;
        }

        private async void confirmBooking_Clicked(object sender, EventArgs e)
        {
            if (ActiveUser.Account.ID == null)
            {
                await Navigation.PushAsync(new CustomerRegistrationPage());
            }

            //Om bokningen har ett id så kommer den från breakfast
            var path = "bookings/room/" + ActiveBooking.RoomID;

            Bookings booking = ActiveBooking.Booking;

            var response = APIServices.Services.PostRequestAsync(path, booking);

            //Får ingen info i responsen står fortfarande Waiting for results eller liknande
            await DisplayAlert("Booking succesful!", "Show bookings", "OK");

            ActiveBooking.Booking = null;
            ActiveBooking.RoomID = null;

            await Navigation.PushAsync(new GuestBookingMainPage());
        }
    }
}
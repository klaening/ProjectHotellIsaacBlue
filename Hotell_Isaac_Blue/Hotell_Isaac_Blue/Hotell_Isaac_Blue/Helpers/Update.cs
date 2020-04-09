using Hotell_Isaac_Blue.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hotell_Isaac_Blue.Helpers
{
    public static class Update
    {
        public static async void UpdateAccountInfo(this Accounts account)
        {
            string path = "accounts/";
            string source = account.ID.ToString();

            var response = APIServices.Services.GetRequest(path, source);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                ActiveUser.Account = JsonConvert.DeserializeObject<Accounts>(result);
            }
        }

        public static async void UpdateBookingInfo(this Bookings booking, long bookingNo)
        {
            string path = "bookings/";
            string source = bookingNo.ToString();

            var response = APIServices.Services.GetRequest(path, source);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                ActiveBooking.Booking = JsonConvert.DeserializeObject<Bookings>(result);
            }



            path = "bookingsrooms/booking/";
            source = bookingNo.ToString();

            response = APIServices.Services.GetRequest(path, source);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                var bookingsRooms = JsonConvert.DeserializeObject<List<BookingsRooms>>(result);
                ActiveBooking.RoomID = bookingsRooms[0].RoomsID;
            }
        }
    }
}

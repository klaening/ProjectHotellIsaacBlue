using System;
using System.Collections.Generic;
using System.Text;
using Hotell_Isaac_Blue.Models;

namespace Hotell_Isaac_Blue
{
    public static class ActiveBooking
    {
        public static Bookings Booking { get; set; }
        public static short? RoomID { get; set; }
    }
}

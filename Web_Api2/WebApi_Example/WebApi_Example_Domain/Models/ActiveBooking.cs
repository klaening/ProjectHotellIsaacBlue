using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Example_Domain.Models
{
    public class ActiveBooking
    {
        public Bookings Booking { get; set; }
        public int RoomID { get; set; }
    }
}

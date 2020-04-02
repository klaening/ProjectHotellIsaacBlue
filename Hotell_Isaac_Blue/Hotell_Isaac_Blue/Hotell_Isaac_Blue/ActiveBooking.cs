using System;
using System.Collections.Generic;
using System.Text;
using Hotell_Isaac_Blue.Tables;

namespace Hotell_Isaac_Blue
{
    public class ActiveBooking
    {
        //Försök få bort TotalDays och RoomType
        public static int TotalDays { get; set; }
        public static RoomTypes RoomType { get; set; }
        public static Bookings Booking { get; set; }
        //Behöver en token för att kunna skapa ett objekt av ActiveBooking och skicka den via PostServiceAsync
        //public int RoomID { get; set; }
    }
}

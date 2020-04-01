using System;
using System.Collections.Generic;
using System.Text;
using Hotell_Isaac_Blue.Tables;

namespace Hotell_Isaac_Blue
{
    public class ActiveBooking
    {
        public static Bookings Booking { get; set; }
        //Behöver en token för att kunna skapa ett objekt av ActiveBooking och skicka den via PostServiceAsync
        //Sätter token på default 8 för testning, senare kommer den att hämta vilket rum beroende vilka som är lediga de datument
        public static int RoomID { get; set; } = 8;
    }
}

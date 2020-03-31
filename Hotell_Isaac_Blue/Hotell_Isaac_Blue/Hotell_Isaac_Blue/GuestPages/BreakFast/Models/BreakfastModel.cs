using System;
using System.Collections.Generic;
using System.Text;

namespace Hotell_Isaac_Blue.GuestPages.BreakFast.Models
{
    public class BreakfastModel
    {
    public bool WantBreakfast { get; set; }
    static string bookingNo;
        public static string BookingNo
        {
            get => bookingNo;
            set
            {
                bookingNo = value;
            }
        }

        
    }
}

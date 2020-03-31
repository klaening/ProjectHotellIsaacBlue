using System;
using System.Collections.Generic;
using System.Text;

namespace Hotell_Isaac_Blue.Guest.GuestBreakfast.Model
{
    public class BreakfastModel
    {
        public bool WantBreakfast { get; set; }
        string bookingNo;
        public string BookingNo
        {
            get => bookingNo;
            set
            {
                bookingNo = value;
            }
            
        }

         
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Hotell_Isaac_Blue.Tables;

namespace Hotell_Isaac_Blue
{
    public class ActiveBooking
    {
        public static Bookings Booking { get; set; }

        internal static void CreateActiveBooking(string result)
        {
            //En lista med all aktuell data i json skriptet
            List<string> wantedResults = Helpers.Helpers.ExtractData(result);

            //Sätter den aktiva användaren till det konto som loggat in
            Booking = new Bookings
            {
                ID = long.Parse(wantedResults[0]),
                QTYPERSONS = short.Parse(wantedResults[1]),
                STARTDATE = DateTime.Parse(wantedResults[2]),
                ENDDATE = DateTime.Parse(wantedResults[3]),
                ETA = DateTime.Parse(wantedResults[4]),
                TIMEARRIVAL = DateTime.Parse(wantedResults[5]),
                TIMEDEPARTURE = DateTime.Parse(wantedResults[6]),
                SPECIALNEEDS = wantedResults[7],
                EXTRABED = bool.Parse(wantedResults[8]),
                PARKING = bool.Parse(wantedResults[9]),
                BREAKFAST = bool.Parse(wantedResults[10]),
                CUSTOMERSID = long.Parse(wantedResults[11]),
                STAFFID = int.Parse(wantedResults[12])
            };
        }
    }
}

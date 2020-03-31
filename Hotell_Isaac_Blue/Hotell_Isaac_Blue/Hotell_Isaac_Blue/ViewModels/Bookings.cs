using System;
using System.Collections.Generic;
using System.Text;

namespace Hotell_Isaac_Blue.ViewModels
{
    public class Bookings
    {
        public long? ID { get; set; }
        public short QTYPERSONS { get; set; }
        public DateTime STARTDATE { get; set; }
        public DateTime ENDDATE { get; set; }
        public DateTime? ETA { get; set; }
        public DateTime? TIMEARRIVAL { get; set; }
        public DateTime? TIMEDEPARTURE { get; set; }
        public string SPECIALNEEDS { get; set; }
        public bool EXTRABED { get; set; }
        public bool? PARKING { get; set; }
        public bool BREAKFAST { get; set; }

        //FOREIGN KEYS
        public long? CUSTOMERSID { get; set; }
        public int? STAFFID { get; set; }
    }
}

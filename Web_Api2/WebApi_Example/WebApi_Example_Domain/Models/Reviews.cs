using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Example_Domain.Models
{
    public class Reviews
    {
        public int ID { get; set; }
        public long CUSTOMERSID { get; set; }
        public short RATING { get; set; }
        public string CUSTOMERREVIEW { get; set; }
        public long BOOKINGSID { get; set; }
    }
}

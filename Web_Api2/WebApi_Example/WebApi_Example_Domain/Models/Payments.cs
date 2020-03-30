using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Example_Domain.Models
{
    public class Payments
    {
        public long ID { get; set; }
        public decimal TOTALCOST { get; set; }
        public string TRANSACTIONTOKEN { get; set; }
        public long BOOKINGSID { get; set; }
        //Borde vara en decimal:
        public int DISCOUNTMONEY { get; set; }
        public long CUSTOMERSID { get; set; }
    }
}

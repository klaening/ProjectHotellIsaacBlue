using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Example_Domain.Models
{
    public class CustomerTypes
    {
        public short ID { get; set; }
        public string TYPENAME { get; set; }
        public decimal DISCOUNTPERCENT { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Example_Domain.Models
{
    public class PhoneNumbers
    {
        public long ID { get; set; }
        public string PHONENUMBER { get; set; }
        public long CUSTOMERSID { get; set; }
        public short PHONENUMBERTYPESID { get; set; }
    }
}

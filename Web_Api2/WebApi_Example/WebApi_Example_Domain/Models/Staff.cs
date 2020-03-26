using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Example_Domain.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string  LASTNAME { get; set; }
        public string PHONENUMBER { get; set; }
        public string EMAIL { get; set; }
        public short DEPARTMENTSID { get; set; }
    }
}

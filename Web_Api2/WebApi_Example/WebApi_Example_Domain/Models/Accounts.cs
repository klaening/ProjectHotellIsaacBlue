using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Example_Domain.Models
{
    public class Accounts
    {
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string USERPASSWORD { get; set; }
        public long CUSTOMERSID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Hotell_Isaac_Blue.Models
{
    public class Accounts
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public long? CustomersID { get; set; }
    }
}

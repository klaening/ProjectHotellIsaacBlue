using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotell_Isaac_Blue.Model
{
    public class Accounts
    {

        private string userName;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

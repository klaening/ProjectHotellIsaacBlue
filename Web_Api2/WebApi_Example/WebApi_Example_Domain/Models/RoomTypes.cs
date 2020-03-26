using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi_Example_Domain.Models
{
    public class RoomTypes
    {
        public short ID { get; set; }
        public string NAME { get; set; }
        public decimal COST { get; set; }
        public short QTYBEDS { get; set; }
    }
}

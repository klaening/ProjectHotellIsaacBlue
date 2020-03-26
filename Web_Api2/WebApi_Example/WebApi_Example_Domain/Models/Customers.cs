namespace WebApi_Example_Domain.Models
{
    public class Customers
    {
        //Primary key
        public long ID { get; set; }
        public string SOCNUMBER { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string EMAIL { get; set; }
        public string STREETADRESS { get; set; }
        public string CITY { get; set; }
        public string COUNTRY { get; set; }
        public string ICE { get; set; }

        //Foreign keys
        public short CUSTOMERTYPESID { get; set; }
    }
}

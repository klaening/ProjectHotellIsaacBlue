using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Hotell_Isaac_Blue.Models
{
    public class Customers
    {
        public int ID { get; set; }
        public string SOCNUMBER { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string EMAIL { get; set; }
        public string STREETADDRESS { get; set; }
        public string CITY { get; set; }
        public string COUNTRY { get; set; }
        public string ICE { get; set; }
        public int CUSTOMERTYPESID { get; set; }

        public static MobileServiceClient client = new MobileServiceClient("https://hotellisaacbluewebapi.azurewebsites.net");

        public async Task<bool> SaveCustomer()
        {
            try
            {
                await client.GetTable<Customers>().InsertAsync(this);
                return true;
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                var response = await msioe.Response.Content.ReadAsStringAsync();
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static async Task<List<Customers>> ReadCustomers()
        {
            return await client.GetTable<Customers>().ToListAsync();
        } 

        public async void HaconBacon()
        {
            var list = client.GetTable<Customers>().ToListAsync();
        }
    }
}

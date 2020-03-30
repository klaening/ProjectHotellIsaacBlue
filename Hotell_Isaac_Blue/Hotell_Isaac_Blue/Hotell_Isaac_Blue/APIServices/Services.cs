using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hotell_Isaac_Blue.APIServices
{
    public class Services
    {
        private const string HOST = "https://hotellisaacbluewebapi.azurewebsites.net/api/";
        public static async Task PostServiceAsync(Object objectclass, string path)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(objectclass);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(HOST + path, content);

            //Kan man använda result för att ta kundens id och sen stoppa den i kontots foreign key?
            //string result = await response.Content.ReadAsStringAsync();
        }

        //public static HttpResponseMessage GetLoginAccountInfo(string username, string password)
        //{
        //    var client = new HttpClient();

        //    string jsonData = username + "/" + password;

        //    //Returnerar Status kod
        //    var response = client.GetAsync(HOST + "accounts/" + jsonData);

        //    return response;
        //}
    }
}

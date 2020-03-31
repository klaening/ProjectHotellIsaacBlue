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

        public static HttpResponseMessage GetService(string[] primaryKeys)
        {
            var client = new HttpClient();

            string jsonData = string.Empty;

            foreach (var key in primaryKeys)
            {
                jsonData += key + "/";
            }

            //Returnerar Status kod
            var response = client.GetAsync("https://hotellisaacbluewebapi.azurewebsites.net/api/accounts/" + jsonData);

            var statusCode = response.Result;

            return statusCode;
        }
    }
}

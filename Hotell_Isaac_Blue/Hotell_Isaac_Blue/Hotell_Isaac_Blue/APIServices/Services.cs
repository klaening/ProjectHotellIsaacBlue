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
        public static async Task PostServiceAsync(string path, Object objectclass)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(objectclass);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:44341/api/" + path, content);

            //Kan man använda result för att ta kundens id och sen stoppa den i kontots foreign key?
            //string result = await response.Content.ReadAsStringAsync();
        }

        public static HttpResponseMessage GetService(string path, string[] primaryKeys)
        {
            var client = new HttpClient();

            string primaryKey = string.Empty;

            foreach (var key in primaryKeys)
            {
                primaryKey += key + "/";
            }

            //Returnerar Status kod
            var response = client.GetAsync("https://hotellisaacbluewebapi.azurewebsites.net/api/" + path + primaryKey);

            var statusCode = response.Result;

            return statusCode;
        }
    }
}

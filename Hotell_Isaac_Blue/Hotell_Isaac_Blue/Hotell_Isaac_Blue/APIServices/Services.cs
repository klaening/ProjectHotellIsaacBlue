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
        public static async Task PostServiceAsync(Object objectclass, string path)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(objectclass);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://hotellisaacbluewebapi.azurewebsites.net/api/" + path, content);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            //string result = await response.Content.ReadAsStringAsync();
        }
    }
}

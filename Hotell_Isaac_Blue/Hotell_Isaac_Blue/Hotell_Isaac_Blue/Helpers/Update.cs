using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hotell_Isaac_Blue.Helpers
{
    public static class Update
    {
        public static async void UpdateAccountInfo(this Accounts account)
        {
            string path = "accounts/";

            string source = account.ID.ToString();
            var response = APIServices.Services.GetRequest(path, source);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                //Returnerar json data för det kontot
                string result = await response.Content.ReadAsStringAsync();
                var activeUser = JsonConvert.DeserializeObject<Accounts>(result);
                ActiveUser.Account = activeUser;
            }
        }
    }
}

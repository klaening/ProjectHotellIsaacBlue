using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hotell_Isaac_Blue
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();

            string jsonData = UsernameEntry.Text+"/"+PasswordEntry.Text;

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            content.Headers.ContentType.CharSet = string.Empty;

            string contentString = content.ToString();

            var response = await client.GetAsync("https://hotellisaacbluewebapi.azurewebsites.net/api/accounts/" + jsonData);
            
            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            string result = await response.Content.ReadAsStringAsync();
        }
    }
}

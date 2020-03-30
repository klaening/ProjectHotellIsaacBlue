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
using Hotell_Isaac_Blue.ViewModels;
using Hotell_Isaac_Blue.Helpers;

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
            if (UsernameEntry.Text == null || PasswordEntry.Text == null)
                await DisplayAlert("Login failed", "Username or password was incorrect", "OK");
            else
            {
                var client = new HttpClient();

                string jsonData = UsernameEntry.Text + "/" + PasswordEntry.Text;

                //Returnerar Status kod
                var response = await client.GetAsync("https://hotellisaacbluewebapi.azurewebsites.net/api/accounts/" + jsonData);


                if (response.ToString().Contains("StatusCode: 200"))
                {
                    //Returnerar json datan för det kontot
                    string result = await response.Content.ReadAsStringAsync();

                    //En lista med all aktuell data i json skriptet
                    List<string> wantedResults = Helpers.Helpers.ExtractData(result);

                    //Sätter den aktiva användaren till det konto som loggat in
                    ActiveUser.account = new Accounts
                    {
                        ID = Convert.ToInt64(wantedResults[0]),
                        UserName = wantedResults[1],
                        UserPassword = wantedResults[2],
                        CustomersID = Convert.ToInt64(wantedResults[3])
                    };

                    await Navigation.PushAsync(new GuestMainPage());
                }
                else
                {
                    await DisplayAlert("Login failed", "Username or password was incorrect", "OK");
                }
            }
        }

        private void SignUpBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Hotell_Isaac_Blue.Tables;
using Hotell_Isaac_Blue.Helpers;
using System.Net;

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
            try
            {
                string path = "accounts/";

                string[] source = new string[] { UsernameEntry.Text, PasswordEntry.Text };

                var response = APIServices.Services.GetService(path, source);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Returnerar json datan för det kontot
                    string result = await response.Content.ReadAsStringAsync();
                    var activeUser = JsonConvert.DeserializeObject<Accounts>(result);
                    ActiveUser.Account = activeUser;

                    await Navigation.PushAsync(new GuestMainPage());
                }
                else
                {
                    LoginFailedMessage();
                }
            }
            catch (Exception)
            {
                LoginFailedMessage();            
            }
        }

        private async void LoginFailedMessage()
        {
            await DisplayAlert("Login failed", "Username or password was incorrect", "OK");
        }

        private void SignUpBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AccountRegistrationPage());
        }
    }
}

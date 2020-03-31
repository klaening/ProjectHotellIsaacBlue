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
using Hotell_Isaac_Blue.Tables;
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
                string[] primaryKeys = new string[] { UsernameEntry.Text, PasswordEntry.Text };

                var response = APIServices.Services.GetService(primaryKeys);

                if (response.IsSuccessStatusCode)
                {
                    //Returnerar json datan för det kontot
                    string result = await response.Content.ReadAsStringAsync();
                    //Skapar en aktiv användare så vi kommer åt datan överallt
                    ActiveUser.CreateActiveUser(result);

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

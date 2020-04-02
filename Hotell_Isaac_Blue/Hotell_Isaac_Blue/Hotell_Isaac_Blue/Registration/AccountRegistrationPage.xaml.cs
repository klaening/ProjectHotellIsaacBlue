using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hotell_Isaac_Blue.Tables;
using System.Net;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountRegistrationPage : ContentPage
    {
        public AccountRegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            //Behöver kolla så att man inte kan lägga till en användare med samma namn
            string userName = userNameEntry.Text;
            string password = passwordEntry.Text;

            string[] userNameKey = { userName };
            string path = "accounts/";

            var response = APIServices.Services.GetService(path, userNameKey);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Username already taken", "Please choose another username", "Try again");
            }
            else
            {
                Accounts account = new Accounts
                {
                    UserName = userName,
                    UserPassword = password
                };

                await APIServices.Services.PostServiceAsync(path, account);
                
                ActiveUser.Account = account;

                await Navigation.PushAsync(new GuestMainPage());
            }
        }

        private void SignInBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}
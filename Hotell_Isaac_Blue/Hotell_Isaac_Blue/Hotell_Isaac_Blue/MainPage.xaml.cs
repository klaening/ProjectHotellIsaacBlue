using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Hotell_Isaac_Blue.Model;

namespace Hotell_Isaac_Blue
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        List<Accounts> accounts = null;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Accounts>();
                accounts = conn.Table<Accounts>().ToList();
            }
        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                bool foundClient = false;

                foreach (var user in accounts)
                {
                    if (user.UserName == UserNameEntry.Text && user.Password == PasswordEntry.Text)
                    {
                        foundClient = true;
                        
                        Navigation.PushAsync(new GuestMainPage(user));
                        break;
                    }
                }

                if (!foundClient)
                    DisplayAlert("Login failed", "User name or password was incorrect", "OK");
            }
        }
    }
}

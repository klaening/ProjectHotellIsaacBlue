using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.Tables;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            Accounts account = new Accounts()
            {
                UserName = EmailEntry.Text,
                Password = PasswordEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Accounts>();
                conn.Insert(account);
            }

            DisplayAlert("User Added", "Succesfully added new user", "OK");

            Navigation.PushAsync(new GuestMainPage(account));
        }

        private void ClearBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hotell_Isaac_Blue.Tables;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            string userName = userNameEntry.Text;
            string password = passwordEntry.Text;

            Accounts account = new Accounts 
            { 
                UserName = userName,
                UserPassword = password
            };

            string path = "accounts/";

            await APIServices.Services.PostServiceAsync(account, path);
        }
    }
}
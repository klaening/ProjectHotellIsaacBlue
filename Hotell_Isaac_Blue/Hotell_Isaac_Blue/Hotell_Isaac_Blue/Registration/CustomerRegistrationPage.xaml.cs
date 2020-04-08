using Hotell_Isaac_Blue.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerRegistrationPage : ContentPage
    {
        public CustomerRegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {

            // Skapa en get på Customer socnumber i web api

            Customers customer = new Customers()
            {
                SOCNUMBER = socNrEntry.Text,
                FIRSTNAME = firstNameEntry.Text,
                LASTNAME = lastNameEntry.Text,
                EMAIL = emailEntry.Text,
                STREETADRESS = streetAdressEntry.Text,
                CITY = cityEntry.Text,
                COUNTRY = countryEntry.Text,
                ICE = iceEntry.Text,
            };

            //Default är 1
            customer.CUSTOMERTYPESID = 1;

            string path = "customers/account/" + ActiveUser.Account.ID;

            await APIServices.Services.PostRequestAsync(path, customer);

            Update.UpdateAccountInfo(ActiveUser.Account);

            var vUpdatedPage = new GuestBookingThirdPage();
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            Navigation.InsertPageBefore(vUpdatedPage, this);

            await Navigation.PopAsync();
        }
    }
}
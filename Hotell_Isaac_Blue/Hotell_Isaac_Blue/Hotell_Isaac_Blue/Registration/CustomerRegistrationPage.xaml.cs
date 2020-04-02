using Hotell_Isaac_Blue.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            ActiveCustomer.Customer = customer;

            string path = "customers/";

            await APIServices.Services.PostServiceAsync(path, customer);
        }
    }
}
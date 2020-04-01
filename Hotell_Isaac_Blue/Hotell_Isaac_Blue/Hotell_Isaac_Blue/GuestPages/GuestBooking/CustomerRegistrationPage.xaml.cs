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

            /* Om active customer redan har info kopplat till sig, så sätts de i textfälten */

            if (ActiveCustomer.Customer != null)
            {
                socNrEntry.Text = ActiveCustomer.Customer.SOCNUMBER;
                firstNameEntry.Text = ActiveCustomer.Customer.FIRSTNAME;
                lastNameEntry.Text = ActiveCustomer.Customer.LASTNAME;
                emailEntry.Text = ActiveCustomer.Customer.EMAIL;
                streetAdressEntry.Text = ActiveCustomer.Customer.STREETADRESS;
                cityEntry.Text = ActiveCustomer.Customer.CITY;
                countryEntry.Text = ActiveCustomer.Customer.COUNTRY;
                iceEntry.Text = ActiveCustomer.Customer.ICE;
            }
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {

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

            await APIServices.Services.PostServiceAsync(customer, path);
        }
    }
}
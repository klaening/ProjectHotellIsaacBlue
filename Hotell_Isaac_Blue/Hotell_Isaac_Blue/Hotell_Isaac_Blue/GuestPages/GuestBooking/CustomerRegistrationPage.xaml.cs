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

        private void RegisterBtn_Clicked(object sender, EventArgs e)
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
}
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
            socNrEntry.Text = ActiveCustomer.customer.SOCNUMBER;
            firstNameEntry.Text = ActiveCustomer.customer.FIRSTNAME;
            lastNameEntry.Text = ActiveCustomer.customer.LASTNAME;
            emailEntry.Text = ActiveCustomer.customer.EMAIL;
            streetAdressEntry.Text = ActiveCustomer.customer.STREETADRESS;
            cityEntry.Text = ActiveCustomer.customer.CITY;
            countryEntry.Text = ActiveCustomer.customer.COUNTRY;
            iceEntry.Text = ActiveCustomer.customer.ICE;
        }
    }
}
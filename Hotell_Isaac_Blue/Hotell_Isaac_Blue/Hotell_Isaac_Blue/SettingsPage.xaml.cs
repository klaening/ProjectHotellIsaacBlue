using Hotell_Isaac_Blue.Tables;
using Newtonsoft.Json;
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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            SetCustomerInfo();
        }

        //Metoden skall ta in ett id 
        private async void SetCustomerInfo()
        {    
            if (ActiveUser.Account.CustomersID.HasValue)
            {
                string path = "customers/";
                string source = ActiveUser.Account.CustomersID.ToString();

                var response = APIServices.Services.GetRequest(path, source);
                var result = await response.Content.ReadAsStringAsync();

                Customers customer = JsonConvert.DeserializeObject<Customers>(result);

                socNrEntry.Text = customer.SOCNUMBER;
                firstNameEntry.Text = customer.FIRSTNAME;
                lastNameEntry.Text = customer.LASTNAME;
                emailEntry.Text = customer.EMAIL;
                cityEntry.Text = customer.CITY;
                countryEntry.Text = customer.COUNTRY;
                streetAdressEntry.Text = customer.STREETADRESS;
                iceEntry.Text = customer.ICE;
            }     
        }

        private async void UpdateInfo_Clicked(object sender, EventArgs e)
        {
            //Informationen uppdateras inte
            string path = "customers/";
            string source = "4";

            var response = APIServices.Services.GetRequest(path, source);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                Customers customer = JsonConvert.DeserializeObject<Customers>(result);

                customer.SOCNUMBER = socNrEntry.Text;
                customer.FIRSTNAME = firstNameEntry.Text;
                customer.LASTNAME = lastNameEntry.Text;
                customer.EMAIL = emailEntry.Text;
                customer.CITY = cityEntry.Text;
                customer.COUNTRY = countryEntry.Text;
                customer.STREETADRESS = streetAdressEntry.Text;
                customer.ICE = iceEntry.Text;

                await APIServices.Services.PutRequestAsync(path, customer);

                await DisplayAlert("Updated!","Your information have been updated","Ok");
                await Navigation.PushAsync(new GuestMainPage());
            }
        }
    }
}
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
        Customers customer;
        string path = "customers/";

        public SettingsPage()
        {
            InitializeComponent();
            SetCustomerInfo();
        }

        private async void SetCustomerInfo()
        {    

            //Kolla över denna lösning på if. Has value kan medföra problem
            if (ActiveUser.Account.CustomersID.HasValue)
            {
                string source = ActiveUser.Account.CustomersID.ToString();

                var response = APIServices.Services.GetRequest(path, source);
                var result = await response.Content.ReadAsStringAsync();

                customer = JsonConvert.DeserializeObject<Customers>(result);

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
            
            if (ActiveUser.Account.CustomersID.HasValue)
            {

                customer.SOCNUMBER = socNrEntry.Text;
                customer.FIRSTNAME = firstNameEntry.Text;
                customer.LASTNAME = lastNameEntry.Text;
                customer.EMAIL = emailEntry.Text;
                customer.CITY = cityEntry.Text;
                customer.COUNTRY = countryEntry.Text;
                customer.STREETADRESS = streetAdressEntry.Text;
                customer.ICE = iceEntry.Text;

                await APIServices.Services.PutRequestAsync(path, customer);

                await DisplayAlert("Updated!", "Your information have been updated.", "Ok");
                await Navigation.PushAsync(new GuestMainPage());
            }
            else if (!ActiveUser.Account.CustomersID.HasValue)
            {

                string path = "customers/account/" + ActiveUser.Account.ID;

                Customers customer = new Customers
                {
                    SOCNUMBER = socNrEntry.Text,
                    FIRSTNAME = firstNameEntry.Text,
                    LASTNAME = lastNameEntry.Text,
                    EMAIL = emailEntry.Text,
                    CITY = cityEntry.Text,
                    COUNTRY = countryEntry.Text,
                    STREETADRESS = streetAdressEntry.Text,
                    ICE = iceEntry.Text,
                    CUSTOMERTYPESID = 1
                };
                    
                await APIServices.Services.PostRequestAsync(path, customer);

                await DisplayAlert("Saved!", "Your information have been saved.", "Ok");
                await Navigation.PushAsync(new GuestMainPage());
            }
        }
    }
}
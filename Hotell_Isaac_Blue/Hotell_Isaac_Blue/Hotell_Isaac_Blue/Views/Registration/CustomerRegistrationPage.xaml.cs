using Hotell_Isaac_Blue.Models;
using Newtonsoft.Json;
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
        Customers customer;

        public CustomerRegistrationPage()
        {
            InitializeComponent();
            if (ActiveUser.Account.CustomersID != null)
                RegisterBtn.Text = "Update information";
            else
                RegisterBtn.Text = "Register";
            SetCustomerInfo();
        }
        private async void SetCustomerInfo()
        {
            //Kolla över denna lösning på if. HasValue kan medföra problem
            if (ActiveUser.Account.CustomersID != null)
            {
                string path = "customers/";
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
        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            if (ActiveUser.Account.CustomersID != null)
            {
                string path = "customers/";

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

                ActiveUser.Account.UpdateAccountInfo();

                var vUpdatedPage = new GuestMainPage();
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                Navigation.InsertPageBefore(vUpdatedPage, this);

                await Navigation.PopAsync();
            }
            else
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
                    CUSTOMERTYPESID = 1
                };

                string path = "customers/account/" + ActiveUser.Account.ID;

                await APIServices.Services.PostRequestAsync(path, customer);

                await DisplayAlert("Saved!", "Your information have been saved.", "Ok");

                ActiveUser.Account.UpdateAccountInfo();

                var vUpdatedPage = new GuestBookingThirdPage();
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                Navigation.InsertPageBefore(vUpdatedPage, this);

                await Navigation.PopAsync();
            }
        }
    }
}
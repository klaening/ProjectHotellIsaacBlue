using Hotell_Isaac_Blue.Guest.GuestBreakfast;
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
    public partial class GuestBreakfastPage : ContentPage
    {
        public GuestBreakfastPage()
        {
            InitializeComponent();
        }


        private void Breakfast_Buy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBreakfastPage2());
        }

        private void FirstPage_Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestMainPage());
        }

        private void Contact_Us_Page_Clicked(object sender, EventArgs e)
        {
            // Redirect to ContactPage
        }

        private void MySettings_Clicked(object sender, EventArgs e)
        {
            // Redirect to users own settingsPage.
        }
    }
}
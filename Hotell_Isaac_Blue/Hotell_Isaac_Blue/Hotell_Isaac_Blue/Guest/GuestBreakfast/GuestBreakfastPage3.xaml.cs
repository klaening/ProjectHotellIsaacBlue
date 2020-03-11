using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue.Guest.GuestBreakfast
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestBreakfastPage3 : ContentPage
    {
        public GuestBreakfastPage3()
        {
           
            InitializeComponent();
        }

        private void Breakfast_AddToBooking_Clicked(object sender, EventArgs e)
        {

        }

        private void FirstPage_Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestMainPage());
        }

        private void Contact_Us_Page_Clicked(object sender, EventArgs e)
        {

        }

        private void MySettings_Clicked(object sender, EventArgs e)
        {

        }
    }
}
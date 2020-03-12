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
    public partial class GuestBookingMainPage : ContentPage
    {
        public GuestBookingMainPage()
        {
            InitializeComponent();
        }

        private void NewBooking_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBookingSecondPage());
        }
    }
}
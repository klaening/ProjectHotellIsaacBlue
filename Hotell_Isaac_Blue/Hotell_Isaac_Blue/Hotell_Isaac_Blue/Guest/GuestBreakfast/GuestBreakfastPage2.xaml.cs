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
    public partial class GuestBreakfastPage2 : ContentPage
    {
        public GuestBreakfastPage2()
        {
            InitializeComponent();
        }
        private void goToBreakfastPage3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBreakfastPage3());
        }
    }
}
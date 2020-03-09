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

        private void GuestBreakfastHome_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hello", "it works", "ok");
        }
    }
}
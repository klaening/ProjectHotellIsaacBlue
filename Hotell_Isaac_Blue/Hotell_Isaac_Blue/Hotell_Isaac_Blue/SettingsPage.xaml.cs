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
        }

        private async void GetCustomer()
        {
            //En metod som hämtar den inloggade kunden och fyller i dess info om det finns.
        }

        private void UpdateInfo_Clicked(object sender, EventArgs e)
        {
            //En metod som updaterar den inloggade kundens uppgifter.
        }
    }
}
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
    public partial class GuestBookingSecondPage : ContentPage
    {
        public GuestBookingSecondPage()
        {
            InitializeComponent();
        }

        private void Result_Btn_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(NavigationPage(new GuestBookingThirdPage));
        }

        private void DatePickerSD_DateSelected(object sender, DateChangedEventArgs e)
        {
            SDDateLabel.Text = e.NewDate.ToShortDateString();

            //string date = e.NewDate.ToLongDateString().ToString();
            //string[] dateSplit = date.Split(' ');
            //char[] dayFull = dateSplit[0].ToCharArray();
            //string dayShort = string.Empty;

            //for (int i = 0; i < 3; i++)
            //{
            //    dayShort += dayFull[i];
            //}

            //date = dayShort;

            //for (int i = 1; i < date.Length; i++)
            //{
            //    date += " " + date[i];
            //}

            //SDDateLabel.Text = date;
        }

        private void DatePickerED_DateSelected(object sender, DateChangedEventArgs e)
        {
            EDDateLabel.Text = e.NewDate.ToShortDateString(); 
        }

        private void EDBtn_Clicked(object sender, EventArgs e)
        {
            DatePickerED.Focus();
        }

        private void SDBtn_Clicked(object sender, EventArgs e)
        {
            DatePickerSD.Focus();
        }
    }
}
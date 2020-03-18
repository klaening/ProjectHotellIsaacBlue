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
        DateTime dateMinValue = DateTime.MinValue;
        DateTime startDate;
        DateTime endDate;
        public GuestBookingSecondPage()
        {
            InitializeComponent();
            AddTapGestures();
        }

        private void Result_Btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBookingThirdPage());
        }
        private void DatePickerSD_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime pickedDate = e.NewDate;

            if (pickedDate < DateTime.Now.Date)
            {
                DisplayAlert("Alert", "Start date can not precede today's date", "OK");
            }
            else if (endDate != dateMinValue && pickedDate >= endDate)
            {
                DisplayAlert("Alert", "End date can not precede start date", "OK");
            }
            else
            {
                startDate = e.NewDate;
                (string date, string year) = ReturnDateAndYear(e.NewDate.ToLongDateString());

                SDDateLabel.Text = date;
                SDYearLabel.Text = year;

                if (EDDateLabel.Text != null)
                    TotDaysLabel.Text = CalculateTotalDays();
            }
        }

        private void DatePickerED_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime pickedDate = e.NewDate;

            if (pickedDate <= DateTime.Now.Date)
            {
                DisplayAlert("Alert", "End date can not precede today's date", "OK");
            }
            else if (pickedDate <= startDate)
            {
                DisplayAlert("Alert", "End date can not precede start date", "OK");
            }
            else
            {
                endDate = e.NewDate;
                (string date, string year) = ReturnDateAndYear(e.NewDate.ToLongDateString());

                EDDateLabel.Text = date;
                EDYearLabel.Text = year;

                if (SDDateLabel.Text != null)
                    TotDaysLabel.Text = CalculateTotalDays();
            }
        }

        private string CalculateTotalDays()
        {
            TimeSpan ts = endDate - startDate;
            int days = (int)ts.TotalDays;

            return "Total days: " + days;
        }

        private (string date, string year) ReturnDateAndYear(string longDate)
        {
            string[] dateSplit = longDate.Split(' ');
            string date = dateSplit[0].Remove(3) + ",";
            dateSplit[1] = dateSplit[1].Remove(3);
            dateSplit[2] = dateSplit[2].Remove(dateSplit[2].Length - 1);
            string year = dateSplit[3];

            for (int i = 1; i < 3; i++)
            {
                date += " " + dateSplit[i];
            }

            return (date, year);
        }

        void AddTapGestures()
        {
            var tapSDFrame = new TapGestureRecognizer();
            tapSDFrame.Tapped += SDFrame_Tapped;
            SDFrame.GestureRecognizers.Add(tapSDFrame);

            var tapEDFrame = new TapGestureRecognizer();
            tapEDFrame.Tapped += EDFrame_Tapped;
            EDFrame.GestureRecognizers.Add(tapEDFrame);

            var tapAddRoomLabel = new TapGestureRecognizer();
            tapAddRoomLabel.Tapped += AddRoomLabel_Tapped;
            AddRoomLabel.GestureRecognizers.Add(tapAddRoomLabel);
        }

        private void SDFrame_Tapped(object sender, EventArgs e)
        {
            DatePickerSD.Focus();
        }

        private void EDFrame_Tapped(object sender, EventArgs e)
        {
            DatePickerED.Focus();
        }

        private void AddRoomLabel_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Want to be able to add more frames", "OK");
        }

        private void Options_Btn_Clicked(object sender, EventArgs e)
        {
            if (OptionsFrame.IsVisible == false)
            {
                Options_Btn.Text = "-";
                OptionsFrame.IsVisible = true;
            }
            else
            {
                Options_Btn.Text = "+";
                OptionsFrame.IsVisible = false;
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.GuestPages.BreakFast.Views;
using Hotell_Isaac_Blue.GuestPages.Parking.Views;
using Hotell_Isaac_Blue.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestMainPage : ContentPage 
    {
        public GuestMainPage()
        {
            InitializeComponent();
            menuUserName.Text = "Hi! " + ActiveUser.Account.UserName;
        }

        private void ParkingFrame_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ParkingFirstPage());
        }

        private void BreakfastFrame_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BreakfastFirstPage());
        }

        private void InfoFrame_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestInfoPage());
        }

        private void BookingsFrame_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBookingMainPage());
        }

        private void BookingBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestBookingMainPage());
        }

        private void InfoBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestInfoPage());
        }

        private void BreakfastBtn_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new GuestBreakfastPage());
        }

        private void ParkingBtn_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new GuestParkingPage());
        }

        private void MyProfileBtn_Clicked(object sender, EventArgs e)
        {
            if (MyProfileFrame.IsVisible == true)
            {
                MyProfileFrame.IsVisible = false;
            }
            else if (MyProfileFrame.IsVisible == false)
            {
                MyProfileFrame.IsVisible = true;
            }
        }

        private async void LogOutBtn_Clicked(object sender, EventArgs e)
        {

            var logOut = await DisplayAlert("Signing out!","Are you sure you want to sign out?", "Sign Out", "Stay");
            if (logOut)
            {
                ActiveUser.Account = null;
                await Navigation.PushAsync(new MainPage());
            }
        }

        private void CloseUserMenu_Clicked(object sender, EventArgs e)
        {
            MyProfileFrame.IsVisible = false;
        }

        private void SettingsBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CustomerRegistrationPage());
        }
    }
}
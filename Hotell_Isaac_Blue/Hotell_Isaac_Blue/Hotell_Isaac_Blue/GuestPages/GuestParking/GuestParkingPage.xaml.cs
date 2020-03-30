﻿using Hotell_Isaac_Blue.Guest;
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
    public partial class GuestParkingPage : ContentPage
    {
        public GuestParkingPage()
        {
            InitializeComponent();
        }

        private void bookParking_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestParkingPage2());
        }
    }
}
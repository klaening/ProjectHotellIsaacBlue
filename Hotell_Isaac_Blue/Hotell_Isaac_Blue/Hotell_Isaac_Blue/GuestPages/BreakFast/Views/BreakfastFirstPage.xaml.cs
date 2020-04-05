
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotell_Isaac_Blue.GuestPages.BreakFast.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Hotell_Isaac_Blue.Tables;
using System.Diagnostics;

namespace Hotell_Isaac_Blue.GuestPages.BreakFast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreakfastFirstPage : ContentPage
    {
       
        public BreakfastFirstPage()
        {           
            InitializeComponent();
            
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            BreakfastModel.BookingNo = BookingEntry.Text;
            await Navigation.PushAsync(new BreakfastSecondPage());

        }
 
    }
}
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hotell_Isaac_Blue;

namespace Hotell_Isaac_Blue
{
    public partial class App : Application
    {
        public static double ScreenHight;
        public static double ScreenWidth;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

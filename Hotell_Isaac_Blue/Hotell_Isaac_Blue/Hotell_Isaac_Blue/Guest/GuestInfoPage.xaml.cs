using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.GoogleMaps;

namespace Hotell_Isaac_Blue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestInfoPage : ContentPage
    {

        public GuestInfoPage()
        {
            InitializeComponent();


            Map map = new Map
            {

            };

            var mapPosition = new Position(57.701629, 11.913693);


            Pin pin = new Pin()
            {

                IsVisible = true,
                Label = "Hotel Isaac",
                Address = "Maskingatan 5, Gothenburg",
                Type = PinType.Place,
                Position = mapPosition

            };

            map.Pins.Add(pin);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(mapPosition, Distance.FromKilometers(30)));

        }

        private void Map_MapClicked(object sender, MapClickedEventArgs e)
        {
       
        }

    }
}
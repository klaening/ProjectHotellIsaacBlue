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
        private void AddMarkers()
        {
            Map map = new Map
            {

            };

            var mapPosition = new Position(57.701629, 11.913693);


            Pin pin = new Pin
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

        public GuestInfoPage()
        {
            InitializeComponent();
            AddMarkers();

        }

        private void Map_MapClicked(object sender, MapClickedEventArgs e)
        {
       
        }

        private void Map_PinClicked(object sender, PinClickedEventArgs e)
        {

        }
    }
}
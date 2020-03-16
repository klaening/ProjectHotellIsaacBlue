using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hotell_Isaac_Blue.Guest
{
    public class StackLayoutTest : ContentPage
    {
        public int RoomNo { get; set; }
        public StackLayoutTest(int roomNo)
        {
            RoomNo = roomNo;

            var layout = new StackLayout();

            var label = new Label
            {
                Text = "Room " + RoomNo,
                FontSize = 28
            };

            var boxview = new BoxView
            {
                Color = Color.Gray,
                HeightRequest = 2,
                HorizontalOptions = LayoutOptions.Fill,
                Margin = new Thickness(0,0,0,20)
            };

            var grid = new Grid();
            grid.HorizontalOptions = LayoutOptions.Center;

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            var pickerList = new List<string> { "Standard", "Double", "Family"};

            var RoomType_Picker = new Picker
            {
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                ItemsSource = pickerList
            };

            var qtyPickerList = new List<int> { 0, 1, 2};

            var GuestsQty_Picker = new Picker
            {
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                ItemsSource = qtyPickerList
            };

            var removeBtn = new Button
            {

            };

            grid.Children.Add(new Label { Text = "Room type", FontSize = 20, VerticalOptions = LayoutOptions.Center }, 0, 0);
            grid.Children.Add(RoomType_Picker, 1, 0);
            grid.Children.Add(new Label { Text = "No of guests", FontSize = 20, VerticalOptions = LayoutOptions.Center }, 0, 1);
            grid.Children.Add(GuestsQty_Picker , 1, 1);

            layout.Children.Add(label);
            layout.Children.Add(boxview);
            layout.Children.Add(grid);

            Content = layout;
        }
    }
}

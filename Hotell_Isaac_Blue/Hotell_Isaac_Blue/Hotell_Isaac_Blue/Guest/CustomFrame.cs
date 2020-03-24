using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hotell_Isaac_Blue.Guest
{
    public class CustomFrame : Frame
    {
        public Label textLabel = null;

        public string RoomLabel { get; set; }

        public int RoomNo { get; set; }

        int pickerWidth = 100;

        public CustomFrame(int roomNo)
        {
            BackgroundColor = Color.Transparent;

            RoomNo = roomNo;
            RoomLabel = "Room " + RoomNo;

            textLabel = new Label { FontSize = 20, Text = RoomLabel };

            var pickerList = new List<string> { "Standard", "Double", "Family" };

            var roomType_Picker = new Picker
            {
                WidthRequest = pickerWidth,
                HorizontalOptions = LayoutOptions.Center,
                ItemsSource = pickerList
            };

            var qtyPickerList = new List<int> { 1, 2 };

            var guestsQty_Picker = new Picker
            {
                WidthRequest = pickerWidth,
                HorizontalOptions = LayoutOptions.Center,
                ItemsSource = qtyPickerList,
                SelectedItem = qtyPickerList[0]
            };

            var removeBtn = new Button
            {
                Text = "Remove room",
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.End,
                FontSize = 10,
                TextColor = Color.Red
            };

            removeBtn.Clicked += RemoveBtn_Clicked;

            var grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition()
                },

                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition()
                }
            };

            grid.Children.Add(new Label { Text = "Room type", FontSize = 20, VerticalOptions = LayoutOptions.Center }, 0, 0);
            grid.Children.Add(roomType_Picker, 1, 0);
            grid.Children.Add(new Label { Text = "No of guests", FontSize = 20, VerticalOptions = LayoutOptions.Center }, 0, 1);
            grid.Children.Add(guestsQty_Picker, 1, 1);
            grid.Children.Add(new Button { Text = "+", Padding = 0, FontSize = 20, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start, CornerRadius = 20, WidthRequest = 40, HeightRequest = 40 }, 0, 2);
            grid.Children.Add(removeBtn, 1, 2);

            var frame = new Frame
            {
                Padding = 10,
                Margin = 0,
                CornerRadius = 10,
                BackgroundColor = Color.GhostWhite,
                HeightRequest = 180,

                Content = new StackLayout
                {
                    Children =
                    {
                        textLabel,

                        new BoxView
                        {
                            Color = Color.Gray,
                            HeightRequest = 2,
                            HorizontalOptions = LayoutOptions.Fill,
                            Margin = new Thickness(0, 0, 0, 20)
                        },

                        grid
                    }
                }
            };

            Content = frame;
        }

        private void RemoveBtn_Clicked(object sender, EventArgs e)
        {
            GuestBookingSecondPage gsp = new GuestBookingSecondPage();

            gsp.RemoveFromStack(RoomNo);
        }
    }
}

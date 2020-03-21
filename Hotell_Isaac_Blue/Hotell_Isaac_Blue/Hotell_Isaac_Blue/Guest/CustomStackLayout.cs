//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xamarin.Forms;

//namespace Hotell_Isaac_Blue.Guest
//{
//    public class CustomStackLayout : ContentPage
//    {
//        public int RoomNo { get; set; }
//        int pickerWidth = 100;
//        //public string labelRoomNo { get; set; } = "Room ";
//        public CustomStackLayout(int roomNo)
//        {
//            RoomNo = roomNo;

//            var label = new Label
//            {
//                Text = "Room " + roomNo,
//                FontSize = 28
//            };

//            var boxview = new BoxView
//            {
//                Color = Color.Gray,
//                HeightRequest = 2,
//                HorizontalOptions = LayoutOptions.Fill,
//                Margin = new Thickness(0,0,0,20)
//            };

//            var pickerList = new List<string> { "Standard", "Double", "Family"};

//            var RoomType_Picker = new Picker
//            {
//                WidthRequest = pickerWidth,
//                HorizontalOptions = LayoutOptions.Center,
//                ItemsSource = pickerList
//            };

//            var qtyPickerList = new List<int> { 0, 1, 2 };

//            var GuestsQty_Picker = new Picker
//            {
//                WidthRequest = pickerWidth,
//                HorizontalOptions = LayoutOptions.Center,
//                ItemsSource = qtyPickerList
//            };

//            var removeBtn = new Button
//            {
//                Text = "Remove room",
//                HorizontalOptions = LayoutOptions.End,
//                FontSize = 10,
//                TextColor = Color.Red
//            };

//            removeBtn.Clicked += RemoveBtn_Clicked;

//            var grid = new Grid
//            {
//                ColumnDefinitions =
//                {
//                    new ColumnDefinition(),
//                    new ColumnDefinition()
//                },
                
//                RowDefinitions =
//                {
//                    new RowDefinition(),
//                    new RowDefinition()
//                }
//            };

//            grid.Children.Add(new Label { Text = "Room type", FontSize = 20, VerticalOptions = LayoutOptions.Center }, 0, 0);
//            grid.Children.Add(RoomType_Picker, 1, 0);
//            grid.Children.Add(new Label { Text = "No of guests", FontSize = 20, VerticalOptions = LayoutOptions.Center }, 0, 1);
//            grid.Children.Add(GuestsQty_Picker, 1, 1);
//            grid.Children.Add(new Button { Text = "+", Padding = 0, FontSize = 20, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start, CornerRadius = 20, WidthRequest = 40, HeightRequest = 40 }, 0, 2);
//            grid.Children.Add(removeBtn, 1, 2);

//            var layout = new StackLayout
//            {
//                Children =
//                {
//                    label,
//                    boxview,
//                    grid
//                }
//            };

//            Content = layout;
//        }

//        private void RemoveBtn_Clicked(object sender, EventArgs e)
//        {
//            //GuestBookingSecondPage gsp = new GuestBookingSecondPage();
            
//            GuestBookingSecondPage.RemoveFromStack(RoomNo);
//        }
//    }
//}

using Hotell_Isaac_Blue.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotell_Isaac_Blue
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class GuestBookingSecondPage : ContentPage
    {
        ScrollView parent = null;
        StackLayout stack1 = null;
        static StackLayout stack2 = null;
        StackLayout stack3 = null;
        StackLayout stackParent = null;
        static int RoomNo;
        static List<CustomFrame> frameList = new List<CustomFrame>();

        public GuestBookingSecondPage()
        {
            //InitializeComponent();

            RoomNo = 1;

            BackgroundColor = Color.LightBlue;

            parent = new ScrollView();

            stack1 = new StackLayout
            {
                Padding = 0,
                Margin = 0,

                Children =
                {
                    new CustomFrame(RoomNo)
                }
            };

            stack2 = new StackLayout
            { 
                Padding = 0,
                Margin = 0
            };

            stack3 = new StackLayout
            {
                Padding = 0,
                Margin = 0
            };

            Button add = new Button
            {
                Text = "+",
                TextColor = Color.Black,
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Aqua,
                BorderColor = Color.SlateGray,
                BorderWidth = 5,
                CornerRadius = 10,
                HeightRequest = 100,
                WidthRequest = 100,
                Opacity = 0.2
            };

            add.Clicked += Add_Clicked;

            stack3.Children.Add(add);

            stackParent = new StackLayout
            {
                Children =
                {
                    stack1,
                    stack2,
                    stack3
                }
            };

            parent.Content = stackParent;

            Content = parent;
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            RoomNo++;

            var frame = new CustomFrame(RoomNo);
            frameList.Add(frame);

            stack2.Children.Add(frame);
        }

        private void OptionsBtn_Clicked(object sender, EventArgs e)
        {
            //More options
        }

        public static void RemoveFromStack(int roomNo)
        {
            int frameIndex = roomNo - 2;

            if (roomNo > 1)
            {
                stack2.Children.Remove(frameList[frameIndex]);
                frameList.Remove(frameList[frameIndex]);
                RoomNo--;

                //Ändra nummer på alla rum med ett rumsnummer högre än det som togs bort
                ChangeRoomNumbers(roomNo);
            }
        }

        private static void ChangeRoomNumbers(int roomNo)
        {
            //Leta efter alla rum som har nummer högre än roomNo
            List<CustomFrame> frameChildren = new List<CustomFrame>();

            foreach (var child in stack2.Children)
            {
                if (child is CustomFrame)
                {
                    frameChildren.Add((CustomFrame)child);
                }
            }

            //Kommer kunna föra in detta i förra loopen
            foreach (var frame in frameChildren)
            {
                if (frame.RoomNo > roomNo)
                {
                    frame.RoomNo -= 1;
                    frame.textLabel.Text = "Room " + frame.RoomNo;
                }
            }
        }

        private void SDFrame_Tapped(object sender, EventArgs e)
        {
            SDPicker.IsVisible = true;
        }
    }
}
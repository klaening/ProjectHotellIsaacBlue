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
        public StackLayout stack = null;
        StackLayout stack2 = null;
        StackLayout stackParent = null;
        public int RoomNo = 1;
        public List<FrameTest> frameList = new List<FrameTest>();

        public GuestBookingSecondPage()
        {
            InitializeComponent();

            BackgroundColor = Color.LightBlue;

            parent = new ScrollView();

            stack = new StackLayout
            { 
                Padding = 0,
                Margin = 0
            };

            stack2 = new StackLayout
            {
                Padding = 0,
                Margin = 0
            };
            stackParent = new StackLayout();

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

            Button remove = new Button
            {
                Text = "-",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Red
            };

            add.Clicked += Add_Clicked;
            remove.Clicked += Remove_Clicked;

            var frame = new FrameTest(RoomNo);
            frameList.Add(frame);

            stack.Children.Add(frame);
            stack2.Children.Add(add);
            stack2.Children.Add(remove);

            stackParent.Children.Add(stack);
            stackParent.Children.Add(stack2);

            parent.Content = stackParent;

            Content = parent;
        }

        public void Remove_Clicked(object sender, EventArgs e)
        {
            if (RoomNo > 1)
            {
                //stack.Children.RemoveAt(roomNo + 1);
                stack.Children.Remove(frameList[RoomNo - 1]);
                frameList.Remove(frameList[RoomNo - 1]);
                RoomNo--;
            }
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            RoomNo++;

            var frame = new FrameTest(RoomNo);
            frameList.Add(frame);

            stack.Children.Add(frame);
        }
    }
}
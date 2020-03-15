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
        StackLayout stack = null;
        public int roomNo = 1;

        public GuestBookingSecondPage()
        {
            InitializeComponent();

            BackgroundColor = Color.LightBlue;

            parent = new ScrollView();

            stack = new StackLayout();

            Button add = new Button
            {
                Text = "+",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Red
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

            Label firstLabel = new Label
            {
                Text = "Label " + roomNo.ToString(),
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                Padding = new Thickness(10),
                BackgroundColor = Color.Green
            };

            stack.Children.Add(add);
            stack.Children.Add(remove);
            stack.Children.Add(firstLabel);

            var frame = new Guest.FrameTest();

            stack.Children.Add(frame);

            parent.Content = stack;

            Content = parent;
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            if (roomNo > 1)
            {
                stack.Children.RemoveAt(roomNo + 1);

                roomNo--;
            }
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            roomNo++;

            var frame = new Guest.FrameTest();

            stack.Children.Add(frame);
        }
    }
}
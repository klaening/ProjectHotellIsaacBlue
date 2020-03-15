using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hotell_Isaac_Blue.Guest
{
    public class FrameTest : Frame
    {
        public FrameTest()
        {
            BackgroundColor = Color.Transparent;

            var frame = new Frame
            {
                Padding = 10,
                Margin = new Thickness(30,10,30,10),
                CornerRadius = 10,
                BackgroundColor = Color.GhostWhite,
                HeightRequest = 180
            };

            var stack = new StackLayoutTest();

            frame.Content = stack.Content;

            Content = frame;
        }
    }
}

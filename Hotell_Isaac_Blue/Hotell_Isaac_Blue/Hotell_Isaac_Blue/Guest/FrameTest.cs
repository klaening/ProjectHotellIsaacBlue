using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hotell_Isaac_Blue.Guest
{
    public class FrameTest : Frame
    {
        public int RoomNo { get; set; }
        public FrameTest(int roomNo)
        {
            RoomNo = roomNo;

            BackgroundColor = Color.Transparent;

            var frame = new Frame
            {
                Padding = 10,
                Margin = new Thickness(0),
                CornerRadius = 10,
                BackgroundColor = Color.GhostWhite,
                HeightRequest = 180
            };

            var stack = new StackLayoutTest(roomNo);

            frame.Content = stack.Content;

            Content = frame;
        }
    }
}

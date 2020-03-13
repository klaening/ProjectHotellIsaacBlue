using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hotell_Isaac_Blue
{
    public class CustomFrame : Frame
    {
        StackLayout parent = null;

        public CustomFrame()
        {
            parent = new StackLayout();

            Grid grid = new Grid()
            {
                
            };

            Frame frame = new Frame
            {

            };


        }
    }
}

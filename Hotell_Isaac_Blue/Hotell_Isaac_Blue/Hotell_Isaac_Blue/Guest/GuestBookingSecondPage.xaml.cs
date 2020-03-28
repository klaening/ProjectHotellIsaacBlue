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
        static int RoomNo;
        static List<CustomFrame> frameList = new List<CustomFrame>();

        public GuestBookingSecondPage()
        {
            InitializeComponent();
        }

        private void OptionsBtn_Clicked(object sender, EventArgs e)
        {
            //More options
        }
        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            RoomNo++;

            var frame = new CustomFrame(RoomNo);
            frameList.Add(frame);

            FrameStack.Children.Add(frame);
        }

        public void RemoveFromStack(int roomNo)
        {
            CustomFrame actualFrame = null;
            //Hitta frame i listan
            foreach (var frame in frameList)
            {
                if (frame.RoomNo == roomNo)
                {
                    actualFrame = frame;
                    break;
                }
            }

            FrameStack.Children.Remove(actualFrame);
        }

        private void SDFrame_Tapped(object sender, EventArgs e)
        {
            SDPicker.IsVisible = true;
        }

        private void EDFrameTapped(object sender, EventArgs e)
        {
            EDPicker.IsVisible = true;
        }
    }
}
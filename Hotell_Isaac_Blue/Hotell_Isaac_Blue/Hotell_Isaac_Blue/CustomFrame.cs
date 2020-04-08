using Hotell_Isaac_Blue.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hotell_Isaac_Blue
{
    public class CustomFrame : Frame
    {
        public long BookingNo { get; set; }

        public CustomFrame(Bookings booking)
        {
            Margin = new Thickness(0, 10);
            Padding = new Thickness(10,10,10,20);
            CornerRadius = 10;
            BookingNo = (long)booking.ID;

            var grid = new Grid();

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
            grid.RowDefinitions.Add(new RowDefinition());

            grid.Children.Add(new Label { Text = "Booking Nr:" }, 0, 0);
            grid.Children.Add(new Label { Text = "Start Date:" }, 1, 0);
            grid.Children.Add(new Label { Text = "End Date: " }, 2, 0);
            grid.Children.Add(new Label { Text = booking.ID.ToString() }, 0, 1);
            grid.Children.Add(new Label { Text = booking.STARTDATE.ToString("dd/MM/yyyy") }, 1, 1);
            grid.Children.Add(new Label { Text = booking.ENDDATE.ToString("dd/MM/yyyy") }, 2, 1);

            StackLayout frameStack = new StackLayout();
            frameStack.Children.Add(grid);

            Content = frameStack;
        }
    }
}

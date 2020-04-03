using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotell_Isaac_Blue.Helpers
{
    public class Helpers
    {
        public static int CalculateTotalDays(DateTime startDate, DateTime endDate)
        {
            TimeSpan ts = endDate - startDate;
            int totalDays = (int)ts.TotalDays;

            return totalDays;
        }
    }
}

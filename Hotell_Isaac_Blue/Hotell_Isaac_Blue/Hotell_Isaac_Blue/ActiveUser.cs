using System;
using System.Collections.Generic;
using System.Text;
using Hotell_Isaac_Blue.Tables;

namespace Hotell_Isaac_Blue
{
    public static class ActiveUser
    {
        public static Accounts Account { get; set; }

        internal static void CreateActiveUser(string result)
        {
            //En lista med all aktuell data i json skriptet
            List<string> wantedResults = Helpers.Helpers.ExtractData(result);

            //Sätter den aktiva användaren till det konto som loggat in
            Account = new Accounts
            {
                ID = Convert.ToInt64(wantedResults[0]),
                UserName = wantedResults[1],
                UserPassword = wantedResults[2],
                CustomersID = Convert.ToInt64(wantedResults[3])
            };
        }
    }
}

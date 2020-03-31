using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotell_Isaac_Blue.Helpers
{
    public class Helpers
    {
        public static List<string> ExtractData(string result)
        {
            string[] resultSplit = result.Split(',');
            List<string> wantedResults = new List<string>();

            foreach (var item in resultSplit)
            {
                var step1 = item;
                string[] step1Array = step1.Split(':');

                wantedResults.Add(step1Array[1]);
            }

            for (int i = 0; i < wantedResults.Count; i++)
            {
                if (wantedResults[i].Contains('"'))
                {
                    wantedResults[i] = wantedResults[i].Remove(0, 1);
                    wantedResults[i] = wantedResults[i].Remove(wantedResults[i].Length - 1);
                }
                if (wantedResults[i].Contains("null"))
                {
                    wantedResults[i] = null;
                }
            }

            return wantedResults;
        }
    }
}

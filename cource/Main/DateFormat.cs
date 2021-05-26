using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cource.Main
{
    class DateFormat
    {
        public static void Format(List<string> spis)
        {
            for (var i = 4; i <= 5; i++)
            {
                spis[i] = spis[i].Replace('.', '-');

                string d = spis[i].Substring(0, 2);
                string y = spis[i].Substring(6, 4);

                spis[i] = y + spis[i].Substring(2, 4) + d;
            }
        }
        public static string FormatStr(string str)
        {
            str = str.Replace('.', '-');

            string d = str.Substring(0, 2);
            string y = str.Substring(6, 4);

            return y + str.Substring(2, 4) + d;
        }
    }
}

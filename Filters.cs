using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RecolectorEmail
{
    public static class Filters
    {
        public static string GetPhoneNumber(string text)
        {
            string found = "";

            while (text.Contains(" "))
            {
                text = text.Replace(" ", "");
            }
            while (text.Contains("-"))
            {
                text = text.Replace("-", "");
            }

            MatchCollection mc = Regex.Matches(text, @"(\d{9,11})");

            foreach (Match m in mc)
            {
                switch (m.Value[0])
                {
                    case '9':
                    case '6':
                    case '7':
                        found = m.Value;
                        break;
                    default:
                        if (found == "")
                            found = m.Value;
                        break;
                }
            }
            
            return found;
        }
    }
}

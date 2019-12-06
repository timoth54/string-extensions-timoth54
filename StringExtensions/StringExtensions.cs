using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string Capitalize(this String str)
        {
            string first = str[0].ToString().ToUpper();
            return first + str.Substring(1);
        }

        public static void Decapitalize(this String str)
        {
            //THIS DOES NOT WORK!!!
            string first = str[0].ToString().ToLower();
            str = first + str.Substring(1);
        }

        public static String Titleize(this String title)
        {
            List<string> articles = new List<string>()
            {
                "a",
                "an",
                "the"
            };

            List<string> parts = new List<string>(title.Split(" "));
            string first;
            string result = "";
            if (articles.Contains(parts[0].ToLower()))
            {
                first = parts[0];
                parts.RemoveAt(0);
                parts.Add(", " + first);

                while (articles.Contains(first.ToLower()))
                {
                    parts.RemoveAt(0);
                    parts.Add(first);
                    first = parts[0];
                }

                foreach (string part in parts)
                {
                    result += part + " ";
                }
            }

            return result;
        }
    }
}

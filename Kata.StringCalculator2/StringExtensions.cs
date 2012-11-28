using System.Collections.Generic;
using System.Linq;

namespace Kata.StringCalculator2
{
    public static class StringExtensions
    {
        public static string[] Split(this string input, string delimiter)
        {
            IList<string> values = new List<string>();

            if (string.IsNullOrEmpty(input)) return values.ToArray();

            int index;

            do
            {
                index = input.IndexOf(delimiter);

                if (index > -1)
                {
                    values.Add(input.Substring(0, index));
                    input = input.Substring(index + delimiter.Length);
                }
                else if (input.Length > 0)
                {
                    values.Add(input);
                }
            } while (index >= 0);

            return values.ToArray();

        }
    }
}
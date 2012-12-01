using System;
using System.Linq;

namespace Kata.StringCalculator2
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = ",";

            if (input.StartsWith("//"))
            {
                int index = input.IndexOf(@"\n", System.StringComparison.InvariantCulture);
                delimiters = input.Substring(2, index - 2);
                input = input.Substring(index + 2);
            }
            else
            {
                input = input.Replace(@"\n", ",");
            }

            input = input.Replace(delimiters, ",");

            var numbers = input.Split(',')
                               .Select(int.Parse)
                               .Where(v=> v < 1001);

            if (numbers.Any(v => v < 0))
            {
                throw new ArgumentOutOfRangeException();
            }

            return numbers.Sum();
        }
    }
}
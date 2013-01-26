using System.Collections.Generic;
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

            char[] separators = ",\n".ToCharArray();
            if (input.StartsWith("//"))
            {
                separators = input.Substring(2, 1).ToCharArray();
                input = input.Substring(4);
            }

            IEnumerable<int> numbers = input.Split(separators).Select(int.Parse).Where(n=> n<=1000);


            return numbers.Sum();
        }
    }
}
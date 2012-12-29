using System;
using System.Linq;

namespace Kata.StringCalculator2
{
    public class StringCalculator
    {
        public int Calc(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            char[] separators = new char[] { ',', '\n' };

            if (input.StartsWith("//"))
            {
                separators = input.Substring(2, 1).ToCharArray();
                input = input.Substring(4);
            }

            var numbers = input.Split(separators).Select(int.Parse).Where(n=> n <= 1000).ToArray();

            if (numbers.Any(n=> n < 0))
            {
                throw new ArgumentOutOfRangeException("input");
            }


            return numbers.Sum();
        }
    }
}
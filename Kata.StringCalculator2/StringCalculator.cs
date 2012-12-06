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

            char[] delimiters = new char[] {',', '\n'};

            if (input.StartsWith("//"))
            {
                delimiters = input.Substring(2, 1).ToCharArray();
                input = input.Substring(input.IndexOf('\n') + 1);
            }

            var numbers = input.Split(delimiters).Select(int.Parse).Where(n=> n <= 1000).ToList();

            if (numbers.Any(n=> n < 0))
            {
                throw new ArgumentOutOfRangeException();
            }

            return numbers.Sum();
        }
    }
}
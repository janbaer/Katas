using System;
using System.Linq;

namespace Kata.StringCalculator
{
    public static class StringExtensions
    {
        public static int Add(this string input)
        {
            const string delimiter = "//[delimiter]\n";

            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            if (input.StartsWith(delimiter))
            {
                input = input.Substring(delimiter.Length);
            }

            var numbers = input.Split(new [] {',', '\n'}).Select(int.Parse).Where(n=>n<=1000).ToList();

            if (numbers.Any(n=> n < 0))
            {
                throw new ArgumentOutOfRangeException();
            }

            return numbers.Sum();
        }
    }
}
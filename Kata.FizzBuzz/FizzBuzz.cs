using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Kata.FizzBuzz
{
    public class FizzBuzz
    {
        public const string FIZZBUZZ = "FIZZBUZZ";
        public const string FIZZ = "FIZZ";
        public const string BUZZ = "BUZZ";

        public string Parse(int input)
        {
            if (input % 3 == 0 && input % 5 == 0)
            {
                return FIZZBUZZ;
            }
            else if (input%3==0)
            {
                return FIZZ;
            }
            else if (input%5 == 0)
            {
                return BUZZ;
            }
            return input.ToString(CultureInfo.InvariantCulture);
        }

        public IEnumerable<string> Generate()
        {
            return Enumerable.Range(1, 100).Select(Parse);
        }
    }
}
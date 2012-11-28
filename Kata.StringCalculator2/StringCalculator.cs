using System;
using System.Text.RegularExpressions;

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

            string delimiter = ",";

            var regex = new Regex(@"^//(?<DELIMITER>.+)\\n(?<INPUT>.+)$");

            var match = regex.Match(input);
            if (match.Success)
            {
                delimiter = match.Groups["DELIMITER"].Value;
                input = match.Groups["INPUT"].Value;
            }
            else
            {
                input = input.Replace(@"\n", delimiter);                
            }

            int sum = 0;
            var numbers = input.Split(delimiter);

            foreach (var number in numbers)
            {
                int value = int.Parse(number);
                if (value < 0)
                {
                    throw new ArgumentException("input");
                }
                sum += value;
            }
            return sum;
        }
    }
}
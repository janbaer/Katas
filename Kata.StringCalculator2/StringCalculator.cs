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

            char[] separators = new char[] {',', '\n'};
            if (input.StartsWith("//"))
            {
                separators = input.Substring(2, input.IndexOf('\n') - 2).ToCharArray();
                input = input.Substring(input.IndexOf('\n') + 1);
            }

            var numbers = input.Split(separators).Select(int.Parse).Where(i=> i < 1001);


            return numbers.Sum();
        }
    }
}
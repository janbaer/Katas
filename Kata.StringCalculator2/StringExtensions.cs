namespace Kata.StringCalculator2
{
    public static class StringExtensions
    {
        public static int Add(this string input)
        {
            return new StringCalculator().Add(input);
        }
    }
}
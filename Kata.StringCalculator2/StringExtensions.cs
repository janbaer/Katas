namespace Kata.StringCalculator2
{
    public static class StringExtensions
    {
        public static int Calc(this string input)
        {
            return new StringCalculator().Calc(input);
        }
    }
}
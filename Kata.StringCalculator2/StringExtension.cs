namespace Kata.StringCalculator2
{
    public static class StringExtension
    {
        public static int Add(this string input)
        {
            return new StringCalculator().Add(input);
        }
    }
}
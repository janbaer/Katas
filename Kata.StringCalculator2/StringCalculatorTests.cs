using System;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Kata.StringCalculator2
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void when_string_is_empty_it_should_return_zero()
        {
            // ARRANGE
            StringCalculator stringCaclulator = new StringCalculator();

            // ACT
            int result = stringCaclulator.Calc("");

            // ASSERT
            Assert.AreEqual(0, result);
        }

        [Test]
        public void when_string_is_One_it_should_return_1()
        {
            // ARRANGE
            StringCalculator stringCalculator = new StringCalculator();

            // ACT
            int result = stringCalculator.Calc("1");

            // ASSERT
            Assert.AreEqual(1, result);
        }

        [Test]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        public void when_string_contains_more_than_two_numbers_it_should_return_the_sum(string input, int expectedResult)
        {
            // ARRANGE
            var stringCalculator = new StringCalculator();

            // ACT
            var result = stringCalculator.Calc(input);

            // ASSERT
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void when_delimiter_is_newline_or_comma_it_should_also_returns_the_sum()
        {
            // ARRANGE
            var stringCalculator = new StringCalculator();

            // ACT
            int sum = stringCalculator.Calc(@"1\n2,3");

            // ASSERT
            Assert.AreEqual(6, sum);
        }

        [Test]
        [TestCase(@"//;\n1;2", 3)]
        [TestCase(@"//=\n1=2", 3)]
        [TestCase(@"//==\n1==2", 3)]
        public void when_string_starts_with_the_definition_of_the_delimiter_it_should_use_this_delimiter(string input, int expectedResult)
        {
            // ARRANGE
            var stringCalculator = new StringCalculator();

            // ACT
            var sum = stringCalculator.Calc(input);

            // ASSERT
            Assert.AreEqual(expectedResult, sum);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void when_number_is_negative_it_should_throws_exception()
        {
            // ARRANGE
            var stringCalulator = new StringCalculator();

            // ACT
            stringCalulator.Calc("-1");

            // ASSERT
        }
    }
}

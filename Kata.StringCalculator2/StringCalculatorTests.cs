using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Kata.StringCalculator2
{
    public class StringCalculatorTests
    {
        [Fact]
        public void when_string_is_empty_it_should_return_zero()
        {
            // ARRANGE
            StringCalculator stringCalculator = new StringCalculator();

            // ACT
            int sum = stringCalculator.Add(string.Empty);

            // ASSERT
            Assert.Equal(0, sum);
        }

        [Fact]
        public void when_string_contains_one_it_should_return_1()
        {
            // ARRANGE
            StringCalculator stringCalculator = new StringCalculator();

            // ACT
            int sum = stringCalculator.Add("1");

            // ASSERT
            Assert.Equal(1, sum);
        }

        [Fact]
        public void when_string_contains_two_numbers_with_a_delimiter_it_should_return_the_sum()
        {
            // ARRANGE
            StringCalculator stringCalculator = new StringCalculator();

            // ACT
            int sum = stringCalculator.Add("1,2");

            // ASSERT
            Assert.Equal(3, sum);
        }

        [Fact]
        public void when_string_contains_newline_and_comma_as_delimiter_it_should_return_the_correct_sum()
        {
            // ARRANGE
            StringCalculator stringCalculator = new StringCalculator();

            // ACT
            int sum = stringCalculator.Add(@"1\n2,3");

            // ASSERT
            Assert.Equal(6, sum);
        }

        [Fact]
        public void when_string_contains_definition_for_delimiter_it_should_use_this_delimiter()
        {
            // ARRANGE
            var stringCalculator = new StringCalculator();

            // ACT
            int sum = stringCalculator.Add(@"//;\n1;2");

            // ASSERT
            Assert.Equal(3, sum);
        }

        [Fact]
        public void add_numbers_greater_than_thousand_should_be_ignored()
        {
            // ARRANGE
            StringCalculator stringCalculator = new StringCalculator();

            // ACT
            int sum = stringCalculator.Add("1,1000,1001,2");

            // ASSERT
            Assert.Equal(1003, sum);
        }

        [Fact]
        public void when_input_contains_a_negative_number_it_should_throws_an_execption()
        {
            // ARRANGE
            StringCalculator stringCalculator = new StringCalculator();

            // ACT
            
            // ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => stringCalculator.Add("-1,2"));
        }

        [Fact]
        public void add_delimiters_can_have_any_length()
        {
            // ARRANGE
            StringCalculator stringCalculator = new StringCalculator();

            // ACT
            var sum = stringCalculator.Add(@"//***\n1***2***3");

            // ASSERT
            Assert.Equal(6, sum);
        }
        
    }

    
}

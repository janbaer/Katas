using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void when_a_number_is_dividable_through_3_it_should_return_fizz()
        {
            string result = new FizzBuzz().Parse(3);
            result.Should().Be("FIZZ");
        }

        [Test]
        public void when_number_is_dividable_through_5_it_should_return_buzz()
        {
            new FizzBuzz().Parse(5).Should().Be("BUZZ");
        }

        [Test]
        public void when_number_is_dividable_through_3_and_5_it_should_return_fizzbuzz()
        {
            new FizzBuzz().Parse(15).Should().Be("FIZZBUZZ");
        }

        [Test]
        public void when_number_is_not_dividable_through_3_and_5_it_should_return_its_numeric_value()
        {
            new FizzBuzz().Parse(1).Should().Be("1");
        }

        [Test]
        public void generate_should_return_a_list_of_numbers_between_1_and_100_where_all_numbers_dividable_through_3_should_be_fizz()
        {
            IEnumerable<string> numbers = new FizzBuzz().Generate();
            numbers.Count().Should().Be(100);

            int i = 0;

            foreach (string number in numbers)
            {
                i++;
                if (i % 15 == 0)
                {
                    number.Should().Be(FizzBuzz.FIZZBUZZ);
                }
                else if (i % 5 == 0)
                {
                    number.Should().Be(FizzBuzz.BUZZ);
                }
                else if (i % 3 == 0)
                {
                    number.Should().Be(FizzBuzz.FIZZ);
                }
            }
        }
    }
}
using System;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Cleanup()
        {
        }


        [Test]
        public void When_string_is_empty_it_should_return_zero()
        {
            string.Empty.Add().Should().Be(0);
        }

        [Test]
        public void When_string_contains_a_single_number_it_should_return_the_value_of_it()
        {
            "1".Add().ShouldBeEquivalentTo(1);    
        }

        [Test]
        public void When_string_contains_a_list_of_numbers_separated_with_comma_it_should_return_the_sum_of_it()
        {
            "1,2,3".Add().Should().Be(6);
        }

        [Test]
        public void When_string_contains_various_separators_it_should_return_also_the_sum_of_all_numbers()
        {
            "1\n2,3".Add().Should().Be(6);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void When_string_contains_a_negative_number_it_should_throw_an_exception()
        {
            "1,-1,2".Add();
        }

        [Test]
        public void When_string_contains_numbers_greater_thousand_it_should_ignore_this_numbers()
        {
            "2,1001".Add().Should().Be(2);
        }

        [Test]
        public void When_the_string_starts_with_a_delimiter_it_shouldignore_it()
        {
            "//[delimiter]\n1,2,3".Add().Should().Be(6);
        }


         
    }
}
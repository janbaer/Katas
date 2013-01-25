using System;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.StringCalculator2
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void when_string_is_empty_it_should_return_0()
        {
            "".Add().ShouldBeEquivalentTo(0);
        }

        [Test]
        public void when_string_contains_a_single_number_it_should_return_the_numeric_value()
        {
            "1".Add().ShouldBeEquivalentTo(1);
        }

        [Test]
        public void when_string_contains_a_list_of_numbers_it_should_return_their_sum()
        {
            "1,2,3".Add().ShouldBeEquivalentTo(6);
        }

        [Test]
        public void when_string_is_contains_newline_it_should_also_accepted_as_separator()
        {
            "1\n2,3".Add().ShouldBeEquivalentTo(6);
        }

        [Test]
        public void when_contains_the_definition_for_the_separator_it_should_use_this_separator()
        {
            "//;\n1;2;3".Add().ShouldBeEquivalentTo(6);
        }

        [Test]
        public void when_string_contains_numbers_greater_than_1000_it_should_ignore_it()
        {
            "1000,1001,2".Add().ShouldBeEquivalentTo(1002);
        }

                                     
    }
}
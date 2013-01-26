using System;
using NUnit.Framework;
using FluentAssertions;

namespace Kata.StringCalculator2
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void When_string_is_empty_it_should_return_0()
        {
            string.Empty.Sum().Should().Be(0);
        }

        [Test]
        public void when_string_contains_a_number_it_should_return_its_value()
        {
            "1".Sum().ShouldBeEquivalentTo(1);
        }

        [Test]
        public void when_string_contains_a_list_of_number_it_should_return_their_sum()
        {
            "1,2,3".Sum().Should().Be(6);
        }

        [Test]
        public void when_string_contains_a_line_break_it_should_accept_this_also_as_separator()
        {
            "1\n2,3".Sum().Should().Be(6);
        }

        [Test]
        public void when_string_begins_with_the_definition_for_the_separator_it_should_use_this_separator()
        {
            "//;\n1;2;3".Sum().Should().Be(6);
        }

        [Test]
        public void when_string_contains_a_number_greater_than_thousand_it_should_ignore_it()
        {
            "1000,1001,2".Sum().Should().Be(1002);
        }

    }
}
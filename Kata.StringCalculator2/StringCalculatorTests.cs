using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;


namespace Kata.StringCalculator2
{
    public class StringCalculatorTests
    {
        [Fact]
        public void when_string_isempty_it_should_return_0()
        {
            string.Empty.Calc().ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void when_string_contains_a_numer_it_should_returns_the_numeric_value()
        {
            "1".Calc().ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void when_string_contains_two_numbers_it_should_return_the_sum()
        {
            "1,2".Calc().ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void when_string_contains_newline_as_sepator_it_should_return_the_sum()
        {
            "1\n2,3".Calc().ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void when_string_begins_with_the_definition_of_the_separator_it_should_use_this_separator()
        {
            "//;\n1;2".Calc().ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void when_string_contains_a_negative_number_it_should_returns_an_outofrangeexception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "1,-2".Calc());
        }

        [Fact]
        public void when_string_contains_numbers_greater_than_1000_it_should_ignore_it()
        {
            "1001,2".Calc().Should().Be(2);
        }


    }
}

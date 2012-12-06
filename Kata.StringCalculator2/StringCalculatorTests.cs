using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kata.StringCalculator2
{
    
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_An_Empty_String_Should_Return_Zero()
        {
            Assert.Equal(0, "".Add());
        }

        [Fact]
        public void Add_ANumber_Should_Return_TheNumericValue()
        {
            Assert.Equal(1, "1".Add());
        }

        [Fact]
        public void Add_TwoNumbers_Should_Return_Their_Sum()
        {
            Assert.Equal(3, "1,2".Add());
        }

        [Fact]
        public void Add_NewLineAsDelimiter_Should_Also_Be_Possible()
        {
            Assert.Equal(6, "1\n2,3".Add());
        }

        [Fact]
        public void Add_Supporting_Different_Delimiters_Should_Also_Be_Possible()
        {
            Assert.Equal(6, "//;\n1;2;3".Add());
        }

        [Fact]
        public void Add_A_negative_number_should_throw_an_outofrangeexception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()=> "1,-2,3".Add());
        }

        [Fact]
        public void Add_numbers_greater_1000_should_be_igored()
        {
            Assert.Equal(2, "2,1001".Add());
        }
    }
}

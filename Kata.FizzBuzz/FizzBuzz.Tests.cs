using System;
using FluentAssertions;

using NUnit.Framework;

namespace Kata.FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(4, "4")]
        public void When_NumberIsNotDivisibleBy3Or5_ItShouldReturnNumberAsString(int number, string result)
        {
            FizzBuzz.Check(number).Should().Be(result);
        }
        
        
        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(6, "Fizz")]
        [TestCase(9, "Fizz")]
        public void When_NumberIsDivisibleBy3_ItShouldReturnFizz(int number, string result)
        {
            FizzBuzz.Check(number).Should().Be(result);
        }       
        
        [Test]
        [TestCase(5, "Buzz")]
        [TestCase(10, "Buzz")]
        public void When_NumberIsDivisibleBy5_ItShouldReturnBuzz(int number, string result)
        {
            FizzBuzz.Check(number).Should().Be(result);
        }

        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(30, "FizzBuzz")]
        [TestCase(45, "FizzBuzz")]
        public void When_NumberIsDivisibleBy3And5_ItShouldReturnFizzBuzz(int number, string result)
        {
            FizzBuzz.Check(number).Should().Be(result);
        }

        /// <summary></summary>
        [Test]
        [Description("")]
        public void GenerateRange_ItShouldReturnAllNumbers()
        {
            // ARRANGE
            var range = new Tuple<int, int>(1, 100);

            // ACT
            var numbers = FizzBuzz.GenerateRange(range);

            // ASSERT
            for (int i = range.Item1; i < range.Item2; i++)
            {
                if(i%3==0 && i%5==0)
                {
                    Assert.AreEqual("FizzBuzz", numbers[i-1]);
                }
                else if (i % 3 == 0)
                {
                    Assert.AreEqual("Fizz", numbers[i-1]);
                }
                else if (i % 5 == 0)
                {
                    Assert.AreEqual("Buzz", numbers[i-1]);
                }
                else
                {
                    Assert.AreEqual(i.ToString(), numbers[i-1]);
                }
            }

        }

    }
}

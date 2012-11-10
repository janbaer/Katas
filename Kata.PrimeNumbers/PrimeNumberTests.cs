using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.PrimeNumbers
{
    [TestClass]
    public class PrimeNumberTests
    {
        public TestContext TestContext { get; set; }
        
        [TestMethod]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        public void IsANumberAPrimeNumber()
        {
            TestContext.Run((int number, bool expectedResult)=>
                                {
                                    Assert.AreEqual(expectedResult, new PrimeNumberGenerator().IsPrimeNumber(number));
                                });
        }

        [TestMethod]
        [TestCase(new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        public void GeneratePrimeNumbers()
        {
            TestContext.Run((IList<int> expectedPrimeNumbers) =>
                                {
                                    var primeNumbers = new PrimeNumberGenerator().Generate(100);
                                    primeNumbers.Should().BeEquivalentTo(expectedPrimeNumbers);
                                });        
        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        [Ignore]
        public void GeneratePrimeManyPrimeNumbers()
        {
            var expectedNumber = 987654319;

            var generator = new PrimeNumberGenerator();
            var primeNumbers = generator.Generate(expectedNumber);

            primeNumbers.Max().Should().Be(expectedNumber);


        }

    }
}

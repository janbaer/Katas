using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.PrimeNumbers
{
    /// <summary>
    /// Summary description for PrimeFactorTests
    /// </summary>
    /// <remarks>
    /// This UnitTests are using the following Nuget packages: ChainingAssertion,  FluentAssertions
    /// </remarks>
    [TestClass]
    public class PrimeFactorTests
    {
        public TestContext TestContext { get; set; }

        [TestCase(1, new int[0] )]
        [TestCase(2, new[] {2})]
        [TestCase(3, new[] {3})]
        [TestCase(4, new[] {2, 2})]
        [TestCase(5, new[] {5})]
        [TestCase(6, new[] {2, 3})]
        [TestCase(9, new[] {3, 3})]
        [TestCase(2*3*5*7*11*13, new[] {2,3,5,7,11,13})]
        [TestMethod]
        public void GetPrimes_OfANumber_ReturnsItPrimes()
        {
            TestContext.Run((int number, IEnumerable<int> expectedPrimes) =>
                                {
                                    number.Primes().Should().BeEquivalentTo(expectedPrimes);
                                });
        }

    }
}

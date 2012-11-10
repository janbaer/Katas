using System;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Kata.RomanNumerus
{

    [TestFixture]
    public class GenerateTests
    {
        [TestCase(0, "")]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(17, "XVII")]
        [TestCase(23, "XXIII")]
        [TestCase(40, "XL")]
        [TestCase(47, "XLVII")]
        [TestCase(50, "L")]
        [TestCase(89, "LXXXIX")]
        [TestCase(90, "XC")]
        [TestCase(100, "C")]
        [TestCase(400, "CD")]
        [TestCase(500, "D")]
        [TestCase(900, "CM")]
        [TestCase(999, "CMXCIX")]
        [TestCase(1000, "M")]
        [TestCase(1944, "MCMXLIV")]
        [TestCase(3999, "MMMCMXCIX")]
        [TestCase(4000, "MMMM")]
        public void WhenInputIsANumber_ItShouldReturnTheRomanNumberPresentation(int number, string expected)
        {
            var result = new RomanNumerals().Generate(number);

            Assert.That(result, Is.EqualTo(expected));
        }

        
    }

    [TestFixture]
    public class ParseTests
    {
        [Test]
        [TestCase(0, "")]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(17, "XVII")]
        [TestCase(23, "XXIII")]
        [TestCase(40, "XL")]
        [TestCase(47, "XLVII")]
        [TestCase(50, "L")]
        [TestCase(89, "LXXXIX")]
        [TestCase(90, "XC")]
        [TestCase(100, "C")]
        [TestCase(400, "CD")]
        [TestCase(500, "D")]
        [TestCase(900, "CM")]
        [TestCase(999, "CMXCIX")]
        [TestCase(1000, "M")]
        [TestCase(1944, "MCMXLIV")]
        [TestCase(3999, "MMMCMXCIX")]
        [TestCase(4000, "MMMM")]
        public void WhenInputIsAValidRomanNumber_ItShouldReturnTheCorrectNumericValue(int expected,string romanNumber)
        {
            Assert.That(new RomanNumerals().Parse(romanNumber), Is.EqualTo(expected));
        }
    }
}

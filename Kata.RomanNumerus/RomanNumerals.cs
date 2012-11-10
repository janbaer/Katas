using System.Collections.Generic;
using System.Text;

namespace Kata.RomanNumerus
{
    public class RomanNumerals
    {
        private class NumberMapping
        {
            public NumberMapping(int value, string presentation)
            {
                Value = value;
                Presentation = presentation;
            }

            public int Value { get; set; }
            public string Presentation { get; set; }
        }

        private readonly IEnumerable<NumberMapping> numberMappings = new List<NumberMapping>()
                                                                         {
                                                                             new NumberMapping(1000, "M"),
                                                                             new NumberMapping(900, "CM"),
                                                                             new NumberMapping(500, "D"),
                                                                             new NumberMapping(400, "CD"),
                                                                             new NumberMapping(100, "C"),
                                                                             new NumberMapping(90, "XC"),
                                                                             new NumberMapping(50, "L"),
                                                                             new NumberMapping(40, "XL"),
                                                                             new NumberMapping(10, "X"),
                                                                             new NumberMapping(9, "IX"),
                                                                             new NumberMapping(5, "V"),
                                                                             new NumberMapping(4, "IV"),
                                                                             new NumberMapping(1, "I"),
                                                                         }; 

        public string Generate(int number)
        {
            var result = new StringBuilder();

            foreach (var numberMapping in numberMappings)
            {
                while (number - numberMapping.Value >= 0)
                {
                    number -= numberMapping.Value;
                    result.Append(numberMapping.Presentation);
                }
            }

            return result.ToString();
        }

        public int Parse(string romanNumerus)
        {
            var number = 0;
            foreach (var mapping in numberMappings)
            {
                while (romanNumerus.StartsWith(mapping.Presentation))
                {
                    number += mapping.Value;
                    romanNumerus = romanNumerus.Substring(mapping.Presentation.Length);
                }
            }
            return number;
        }
    }
}
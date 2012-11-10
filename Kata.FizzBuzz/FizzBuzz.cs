using System;
using System.Collections.Generic;

namespace Kata.FizzBuzz
{
    public class FizzBuzz
    {
        private const string FIZZ_BUZZ = "FizzBuzz";
        private const string FIZZ = "Fizz";
        private const string BUZZ = "Buzz";

        public static string Check(int number)
        {
            if (IsFizzBuzz(number))
            {
                return FIZZ_BUZZ;
            }
            else if(IsFizz(number))
            {
                return FIZZ;
            }
            else if (IsBuzz(number))
            {
                return BUZZ;
            }

            return number.ToString();
        }

        private static bool IsFizz(int number)
        {
            return number%3 == 0;
        }

        private static bool IsBuzz(int number)
        {
            return number%5 == 0;
        }

        private static bool IsFizzBuzz(int number)
        {
            return IsFizz(number) && IsBuzz(number);
        }


        public static IList<string> GenerateRange(Tuple<int, int> range)
        {
            var list = new List<string>();
            for (int i = range.Item1; i <= range.Item2; i++)
            {
                if (IsFizzBuzz(i))
                {
                    list.Add(FIZZ_BUZZ);    
                }   
                else if(IsFizz(i))
                {
                    list.Add(FIZZ);
                }
                else if(IsBuzz(i))
                {
                    list.Add(BUZZ);
                }
                else
                {
                    list.Add(i.ToString());
                }
            }
            return list;
        }
    }
}
using System.Collections.Generic;

namespace Kata.PrimeNumbers
{
    public static class PrimesExtension
    {
        public static List<int> Primes(this int number)
        {
            var primes = new List<int>();

            var divisor = 2;

            while (number > 1)
            {
                for(; number % divisor == 0; number/=divisor)
                {
                    primes.Add(divisor);
                }
                divisor++;
            }
            if (number > 1)
            {
                primes.Add(number);
            }

            return primes;
        }     

    }
}
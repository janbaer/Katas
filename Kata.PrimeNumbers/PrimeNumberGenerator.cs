using System.Collections.Generic;

namespace Kata.PrimeNumbers
{
    public class PrimeNumberGenerator
    {
        public IEnumerable<int> Generate(int max)
        {        
            var eliminated = new bool[max+1];

            for (uint i = 2; i <= max; i++)
            {
                if (eliminated[i] == false)
                {
                    for (uint j = i*i; j <= max; j+=i)
                    {
                        eliminated[j] = true;
                    }

                    yield return (int)i;
                }    
            }
        }

        public bool IsPrimeNumber(int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }

            for (int number = 2; number < candidate; number++ )
            {
                if (candidate % number == 0)
                {
                    return false;
                }    
            }  
            
            return true;
        }
    }
}
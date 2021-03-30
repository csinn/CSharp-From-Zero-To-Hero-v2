using System;
using System.Collections.Generic;
using System.Text;

namespace BootCampV2.SmallProjects.PrimeNumbers
{
    class PrimeNumbers
    {
        static bool IsPrime(int number)
        {
            for (int divider = 2; divider <= number / 2; divider++)
            {
                if (number % divider == 0)
                {
                    // if a number divides from another number, other than 1 and itself- then it is not a prime.
                    return false;
                }
            }

            // otherwise, the number is prime.
            return true;
        }

        static void PrintPrimes(int n)
        {
            for (int number = 1; number < n; number++)
            {
                if (IsPrime(number))
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}

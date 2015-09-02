using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFactorsKata
{
    public class PrimeFinder
    {
        public IEnumerable<Int32> Generate(Int32 factorableNumber)
        {
            var factorList = new List<Int32>();

            var potentialFactor = 2;
            while (factorableNumber > 1)
            {
                if (factorableNumber % potentialFactor == 0)
                {
                    factorList.Add(potentialFactor);
                    factorableNumber /= potentialFactor;
                }
                else
                {
                    potentialFactor++;
                }
            }

            if (factorList.Any())
                return factorList;

            throw new NonPrimeOrCompositeException();
        }
    }

    public class NonPrimeOrCompositeException : Exception
    { }
}

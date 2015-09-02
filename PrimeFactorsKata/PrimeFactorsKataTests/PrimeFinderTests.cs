using NUnit.Framework;
using PrimeFactorsKata;
using System;
using System.Collections.Generic;

namespace PrimeFactorsKataTests
{
    [TestFixture]
    public class PrimeFinderTests
    {
        private PrimeFinder primeFinder;
        private List<Int32> expected;

        [SetUp]
        public void Setup() 
        {
            primeFinder = new PrimeFinder();
            expected = new List<Int32>();
        }

        [Test]
        public void OneThrowsAnException()
        {
            Assert.Throws<NonPrimeOrCompositeException>(() => primeFinder.Generate(1));
        }

        [Test]
        public void PrimeFactorsOfTwoIsTwo()
        {
            var primeList = primeFinder.Generate(2);
            expected.Add(2);

            Assert.AreEqual(expected, primeList);
        }

        [Test]
        public void PrimeFactorOfThreeIsThree()
        {
            var primeList = primeFinder.Generate(3);
            expected.Add(3);

            Assert.AreEqual(expected, primeList);
        }

        [Test]
        public void PrimeFactorsOfFourIsTwoAndTwo()
        {
            var primeList = primeFinder.Generate(4);
            expected.AddRange(new[] { 2, 2 });

            Assert.AreEqual(expected, primeList);
        }

        [Test]
        public void PrimeFactorOfFiveIsFive()
        {
            var primeList = primeFinder.Generate(5);
            expected.Add(5);

            Assert.AreEqual(expected, primeList);
        }

        [Test]
        public void PrimeFactorsOfSixIsTwoAndThree()
        {
            var primeList = primeFinder.Generate(6);
            expected.AddRange(new[] { 2, 3 });

            Assert.AreEqual(expected, primeList);
        }

        [Test]
        public void PrimeFactorsOfEightIsThreeTwos()
        {
            var primeList = primeFinder.Generate(8);
            expected.AddRange(new[] { 2, 2, 2 });

            Assert.AreEqual(expected, primeList);
        }

        [Test]
        public void PrimeFactorsOfTenIsTwoAndFive()
        {
            var primeList = primeFinder.Generate(10);
            expected.AddRange(new[] { 2, 5 });

            Assert.AreEqual(expected, primeList);
        }

        [Test]
        public void PrimeFactorsOfTwelveIsTwoAndTwoAndThree()
        {
            var primeList = primeFinder.Generate(12);
            expected.AddRange(new[] { 2, 2, 3 });

            Assert.AreEqual(expected, primeList);
        }

        [Test]
        public void PrimeFactorsOfSixHundredAndEightyFiveIsFiveAndOneHundredThirtySeven()
        {
            var primeList = primeFinder.Generate(685);
            expected.AddRange(new[] { 5, 137 });

            Assert.AreEqual(expected, primeList);
        }
    }
}

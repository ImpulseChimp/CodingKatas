using VideoStoreKata;
using NUnit.Framework;
using System;

namespace VideoStoreTests
{
    [TestFixture]
    public class RentalTests
    {

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(6)]
        public void CreatingAndSettingRentalData(Int32 defaultRentalDays)
        {
            Movie defaultMovie = new Movie("Test Movie 1: The Reckoning...", new ChildrensMovie());
            Rental testRental = new Rental(defaultMovie, defaultRentalDays);

            Assert.That(defaultMovie, Is.EqualTo(testRental.GetMovie()));
            Assert.That(defaultRentalDays, Is.EqualTo(testRental.GetDaysRented()));
        }
    }
}

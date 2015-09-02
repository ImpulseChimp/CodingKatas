using VideoStoreKata;
using System;
using NUnit.Framework;

namespace VideoStoreKataTests
{

    [TestFixture]
    public class MovieTests
    {

        [Test]
        public void SetPriceCodeForMovie()
        {
            Movie newMovie = new Movie("Movie Title 6: Title Rebirthed", new ChildrensMovie());
            Assert.That(2 == newMovie.type.GetPriceCode());

            newMovie.type = new RegularMovie();
            Assert.That(0 == newMovie.type.GetPriceCode());
        }
    }
}

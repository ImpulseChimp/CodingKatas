using System;

namespace VideoStoreKata
{
    public class NewMovie : IMovie
    {
        private const Double PriceMultiplier = 3.0;
        private const Int32 NewMovieCode = 1;

        public Int32 GetPriceCode()
        {
            return NewMovieCode;
        }

        public Double GetTotalPrice(Int32 daysRented)
        {
            return daysRented * PriceMultiplier;
        }
    }
}

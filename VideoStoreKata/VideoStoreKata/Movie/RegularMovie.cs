using System;

namespace VideoStoreKata
{
    public class RegularMovie : IMovie
    {
        private const Double PriceMultiplier = 1.5;
        private const Double BasePrice = 2.0;
        private const Int32 DayPriceFilter = 2;
        private const Int32 RegularMovieCode = 0;

        public Int32 GetPriceCode()
        {
            return RegularMovieCode;
        }

        public Double GetTotalPrice(Int32 daysRented)
        {
            var totalCost = BasePrice;
            if (daysRented > DayPriceFilter)
                totalCost += (daysRented - DayPriceFilter) * PriceMultiplier;

            return totalCost;
        }
    }
}

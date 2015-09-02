using System;

namespace VideoStoreKata
{
    public class ChildrensMovie : IMovie
    {
        private const Double BasePrice = 1.5;
        private const Double PriceMultiplier = 1.5;
        private const Int32 DayPriceFilter = 3;
        private const Int32 ChildrensMovieCode = 2;

        public Int32 GetPriceCode() 
        {
            return ChildrensMovieCode;
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

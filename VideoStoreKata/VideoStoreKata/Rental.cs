using System;

namespace VideoStoreKata
{
    public class Rental
    {
        private const Int32 RentalPointValue = 1;
        private Movie movie;
        private Int32 daysRented;

        public Rental(Movie movie, Int32 daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public Int32 GetDaysRented()
        {
            return daysRented;
        }

        public Int32 GetRenterPoints()
        {
            if (movie.type.GetPriceCode() == new NewMovie().GetPriceCode())
                return 2 * RentalPointValue;

            return RentalPointValue;
        }

        public Movie GetMovie()
        {
            return movie;
        }

        public Double GetCost()
        {
            return movie.type.GetTotalPrice(daysRented);
        }
    }
}

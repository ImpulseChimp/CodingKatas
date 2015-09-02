using System;

namespace VideoStoreKata
{
    public interface IMovie
    {
        Int32 GetPriceCode();
        Double GetTotalPrice(Int32 daysRented);
    }
}

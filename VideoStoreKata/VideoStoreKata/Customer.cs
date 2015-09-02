using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoStoreKata
{
    public class Customer
    {
        private List<Rental> rentals;
        public String Name { get; private set; }

        public Customer(String name)
        {
            Name = name;
            rentals = new List<Rental>();
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public String Statement()
        {
            var header = GetHeader();
            var body = GetBody(rentals);
            var footer = GetFooter(CalculateTotalCost(rentals), CalculateRenterPoints(rentals));

            return String.Format("{0}{1}{2}", header, body, footer);
        }

        private String GetHeader()
        {
            return String.Format("Rental Record for {0}\n", Name);
        }

        private String GetBody(List<Rental> rentals)
        {
            var body = String.Empty;
            foreach (var rental in rentals)
                body += String.Format("\t{0}\t{1}\n", rental.GetMovie().Title, Convert.ToString(rental.GetCost()));

            return body;
        }

        private String GetFooter(Double totalAmount, Int32 frequentRenterPoints)
        {
            return String.Format("You owed {0}\nYou earned {1} frequent renter points\n", Convert.ToString(totalAmount),
               Convert.ToString(frequentRenterPoints));
        }

        private Double CalculateTotalCost(IEnumerable<Rental> rentals)
        {
            return rentals.Sum(r => r.GetCost());
        }

        private Int32 CalculateRenterPoints(IEnumerable<Rental> rentals)
        {
            return rentals.Sum(r => r.GetRenterPoints());
        }
    }
}

using VideoStoreKata;
using NUnit.Framework;
using System;

namespace VideoStoreTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer testCustomer;

        [SetUp]
        public void Initialize()
        {
            testCustomer = new Customer("Joe Shmoe");
        }

        [Test]
        public void CreateCustomerSuccessfully()
        {
            Assert.IsTrue(testCustomer.Name.Equals("Joe Shmoe"));
        }

        [Test]
        public void StatementWithZeroRentals()
        {
            var statment = testCustomer.Statement();
            var correctStatment = "Rental Record for Joe Shmoe\nYou owed 0\nYou earned 0 frequent renter points\n";
            Assert.AreEqual(correctStatment, statment);
        }

        [Test]
        public void StatmentWithOneRental()
        {
            testCustomer.AddRental(new Rental(new Movie("Test", new ChildrensMovie()), 2));

            var statment = testCustomer.Statement();
            var correctStatment = "Rental Record for Joe Shmoe\n\tTest\t1.5\nYou owed 1.5\nYou earned 1 frequent renter points\n";
            Assert.AreEqual(correctStatment, statment);
        }

        [Test]
        public void StatmentWithFiveRentals()
        {
            testCustomer.AddRental(new Rental(new Movie("One", new RegularMovie()), 9));
            testCustomer.AddRental(new Rental(new Movie("Two", new RegularMovie()), 5));
            testCustomer.AddRental(new Rental(new Movie("Three", new NewMovie()), 4));
            testCustomer.AddRental(new Rental(new Movie("Four", new ChildrensMovie()), 8));
            testCustomer.AddRental(new Rental(new Movie("Five", new ChildrensMovie()), 1));

            var statment = testCustomer.Statement();
            var correctStatment = "Rental Record for Joe Shmoe\n";
            correctStatment += "\tOne\t12.5\n";
            correctStatment += "\tTwo\t6.5\n";
            correctStatment += "\tThree\t12\n";
            correctStatment += "\tFour\t9\n";
            correctStatment += "\tFive\t1.5\n";
            correctStatment += "You owed 41.5\nYou earned 6 frequent renter points\n";
            Assert.AreEqual(correctStatment, statment);
        }

        [Test]
        public void StatmentWithThreeNewMovies()
        {
            testCustomer.AddRental(new Rental(new Movie("One", new NewMovie()), 5));
            testCustomer.AddRental(new Rental(new Movie("Two", new NewMovie()), 5));
            testCustomer.AddRental(new Rental(new Movie("Three", new NewMovie()), 5));

            var statment = testCustomer.Statement();
            var correctStatment = "Rental Record for Joe Shmoe\n";
            correctStatment += "\tOne\t15\n";
            correctStatment += "\tTwo\t15\n";
            correctStatment += "\tThree\t15\n";
            correctStatment += "You owed 45\nYou earned 6 frequent renter points\n";
            Assert.AreEqual(correctStatment, statment);
        }
    }
}

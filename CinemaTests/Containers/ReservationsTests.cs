using System;
using Cinema.Containers;
using Cinema.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaTests.Containers
{
    [TestClass()]
    public class ReservationsTests
    {
        //[TestMethod()]
        //public void ReservationsTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void AddTest()
        {
            // Arrange.
            var shows = PopulateShows();
            var show = shows.Items[1];
            var reservationExpected = new Reservation(101, new PersonalData("Piotr", "Pyra", "321365987"), show, new Tuple<int, int>(3, 5));

            // Act.
            show.Reservations.Add(new PersonalData("Piotr", "Pyra", "321365987"), show, new Tuple<int, int>(3, 5));

            // Assert.
            var expected = true;
            var actual = show.Reservations.Items[101].Equals(reservationExpected);
            Assert.AreEqual(expected, actual);
        }

        private Shows PopulateShows()
        {
            Movies movies = new Movies();
            Shows shows = new Shows();
            movies.Add("Noc żywych prowadzących", Convert.ToDateTime("1996-12-12"), 125, "Roman R.", 17,
                "Matematyczny");
            movies.Add("Dogłębna analiza", Convert.ToDateTime("2012-11-26"), 125, "Pedro", 19, "Polski");

            shows.Add(Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            shows.Add(Convert.ToDateTime("2017-12-12 17:00"), 120, 15, movies.Items[1]);
            shows.Add(Convert.ToDateTime("2017-12-12 8:00"), 120, 15, movies.Items[2]);

            return shows;
            //shows.Items[1].AddReservation(new PersonalData("Bogdan", "Bobek", "123456789"),
            //    new Tuple<int, int>(5, 6));
            //shows.Items[1].AddReservation(new PersonalData("Zenon", "Ziemniak", "321654987"),
            //    new Tuple<int, int>(5, 7));
            //shows.Items[1].AddReservation(new PersonalData("Klaudiusz", "Kalafior", "321632387"),
            //    new Tuple<int, int>(3, 4));
            //shows.Items[1].AddReservation(new PersonalData("Piotr", "Pyra", "321365987"),
            //    new Tuple<int, int>(3, 5));
            //shows.Items[1].AddReservation(new PersonalData("Bartek", "Brokół", "854654987"),
            //    new Tuple<int, int>(3, 6));
            //shows.Items[2].AddReservation(new PersonalData("Bogdan", "Bobek", "123456789"),
            //    new Tuple<int, int>(7, 6));
        }
    }
}
using System;
using System.Linq;
using Cinema.Containers;
using Cinema.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaTests.Containers
{
    [TestClass()]
    public class ShowsTests
    {
        /// <summary>
        ///     Dodawanie jednego seansu.
        /// </summary>
        [TestMethod()]
        public void AddTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var showsExpected = new Shows();
            Show showExpected = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            showsExpected.Items.Add(showExpected.ID, showExpected);

            // Act.
            shows.Add(Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);

            // Assert.
            var expected = true;
            var actual = showsExpected.Items[1].Equals(shows.Items[1]);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Usuwanie jednego seansu po zadanym ID.
        /// </summary>
        [TestMethod()]
        public void RemoveByIdTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var showsExpected = new Shows();
            var show1 = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            shows.Items.Add(1, show1);
            showsExpected.Items.Add(1, show1);

            // Act.
            shows.Remove(1);
            showsExpected.Items.Remove(1);

            // Assert.
            var expected = true;
            var actual = showsExpected.Equals(shows);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Usuwanie jednego seansu po zadanym ID; seans o takim ID nie znajduje się w kontenerze.
        /// </summary>
        [TestMethod()]
        public void RemoveByWrongIdTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var show1 = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            shows.Items.Add(1, show1);

            // Act.
            var actual = shows.Remove(2);

            // Assert.
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Usuwanie wszystkich (1) seansów na film o zadanym tytule.
        /// </summary>
        [TestMethod()]
        public void RemoveByTitleTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var showsExpected = new Shows();
            var show1 = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            shows.Items.Add(1, show1);
            showsExpected.Items.Add(1, show1);

            // Act.
            shows.Remove(movies.Items[1].Title);
            showsExpected.Items.Remove(1);

            // Assert.
            var expected = true;
            var actual = showsExpected.Equals(shows);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Usuwanie wszystkich (3) seansów na film o zadanym tytule.
        /// </summary>
        [TestMethod()]
        public void RemoveByTitleMultipleTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var show1 = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            var show2 = new Show(2, Convert.ToDateTime("2017-12-13 13:00"), 120, 15, movies.Items[1]);
            var show3 = new Show(3, Convert.ToDateTime("2017-12-14 14:00"), 120, 15, movies.Items[1]);
            shows.Items.Add(1, show1);
            shows.Items.Add(2, show2);
            shows.Items.Add(3, show3);

            // Act.
            shows.Remove(movies.Items[1].Title);

            // Assert.
            var expected = false;
            var actual = shows.Items.Any();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Usuwanie wszystkich (0) seansów na film o zadanym tytule; seans na taki film nie istnieje.
        /// </summary>
        [TestMethod()]
        public void RemoveByTitleFromEmptyTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();

            // Act.
            var actual = shows.Remove(movies.Items[1].Title);

            // Assert.
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Wyszukiwanie wszystkich (2) seansów na film o zadanym tytule.
        /// </summary>
        [TestMethod()]
        public void SearchByTitleTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var show1 = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            var show2 = new Show(2, Convert.ToDateTime("2017-12-14 14:00"), 120, 15, movies.Items[1]);
            shows.Items.Add(1, show1);
            shows.Items.Add(2, show2);

            // Act.
            var foundShows = shows.Search(movies.Items[1].Title);

            // Assert.
            var expected = 2;
            var actual = foundShows.Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Wyszukiwanie wszystkich (0) seansów na film o zadanym tytule; tytuł jest pustą zmienną string.
        /// </summary>
        [TestMethod()]
        public void SearchByEmptyTitleTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var show1 = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            var show2 = new Show(2, Convert.ToDateTime("2017-12-14 14:00"), 120, 15, movies.Items[1]);
            shows.Items.Add(1, show1);
            shows.Items.Add(2, show2);

            // Act.
            var foundShows = shows.Search("");

            // Assert.
            var expected = 0;
            var actual = foundShows.Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Wyszukiwanie wszystkich (0) seansów na film o zadanym tytule; tytuł jest null.
        /// </summary>
        [TestMethod()]
        public void SearchByNullTitleTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var show1 = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            var show2 = new Show(2, Convert.ToDateTime("2017-12-14 14:00"), 120, 15, movies.Items[1]);
            shows.Items.Add(1, show1);
            shows.Items.Add(2, show2);

            // Act.
            var foundShows = shows.Search(null);

            // Assert.
            var expected = 0;
            var actual = foundShows.Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Wyszukiwanie pojedynczego seansu po dacie.
        /// </summary>
        [TestMethod()]
        public void SearchByDateTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var show1 = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            var show2 = new Show(2, Convert.ToDateTime("2017-12-14 14:00"), 120, 15, movies.Items[1]);
            shows.Items.Add(1, show1);
            shows.Items.Add(2, show2);

            // Act.
            var foundShow = shows.Search(Convert.ToDateTime("2017-12-14 14:00"));

            // Assert.
            var expected = true;
            var actual = foundShow.Equals(show2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Wyszukiwanie pojedynczego seansu po dacie; data jest null.
        /// </summary>
        [TestMethod()]
        public void SearchByDateNullTest()
        {
            // Arrange.
            var movies = PopulateMovies();
            var shows = new Shows();
            var show1 = new Show(1, Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            var show2 = new Show(2, Convert.ToDateTime("2017-12-14 14:00"), 120, 15, movies.Items[1]);
            shows.Items.Add(1, show1);
            shows.Items.Add(2, show2);

            // Act.
            var foundShow = shows.Search(Convert.ToDateTime(null));

            // Assert.
            Assert.AreEqual(null, foundShow);
        }

        private Movies PopulateMovies()
        {
            Movies movies = new Movies();
            movies.Add("Noc żywych prowadzących", Convert.ToDateTime("1996-12-12"), 125, "Roman R.", 17,
                "Matematyczny");
            movies.Add("Dogłębna analiza", Convert.ToDateTime("2012-11-26"), 125, "Pedro", 19, "Polski");
            return movies;
        }
    }
}
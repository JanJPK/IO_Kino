using System;
using System.Collections.Generic;

namespace Cinema.Items
{
    public class Show : ICinemaItem
    {
        #region Constructors and Destructors

        public Show(int id, DateTime date, int length, float ticketPrice, Movie movie)
        {
            ID = id;
            Date = date;
            Length = length;
            TicketPrice = ticketPrice;
            Movie = movie;
        }

        #endregion

        #region Public Properties

        public DateTime Date { get; set; }
        public int ID { get; set; }
        public int Length { get; set; }
        public Movie Movie { get; set; }
        public bool[,] Seats { get; set; }
        public float TicketPrice { get; set; }

        #endregion

        #region Public Methods and Operators

        public override bool Equals(object obj)
        {
            var seans = obj as Show;
            return seans != null &&
                   ID == seans.ID &&
                   Date == seans.Date &&
                   Length == seans.Length &&
                   TicketPrice == seans.TicketPrice &&
                   EqualityComparer<Movie>.Default.Equals(Movie, seans.Movie);
        }

        public override int GetHashCode()
        {
            var hashCode = -225525295;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + TicketPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Movie>.Default.GetHashCode(Movie);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool[,]>.Default.GetHashCode(Seats);
            return hashCode;
        }

        public override string ToString()
        {
            // TODO
            return base.ToString();
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;

namespace Cinema.Items
{
    /// <summary>
    ///     Rezerwacja; zawiera dane klienta (PersonalData).
    /// </summary>
    public class Reservation : ICinemaItem
    {
        #region Constructors and Destructors

        public Reservation(int id, PersonalData personalData, Show show, Tuple<int, int> seat)
        {
            ID = id;
            PersonalData = personalData;
            Show = show;
            Seat = seat;
        }

        #endregion

        #region Public Properties

        public int ID { get; }
        public PersonalData PersonalData { get; set; }
        public Tuple<int, int> Seat { get; set; }
        public Show Show { get; set; }

        #endregion

        #region Public Methods and Operators

        public override bool Equals(object obj)
        {
            var reservation = obj as Reservation;
            return reservation != null &&
                   EqualityComparer<PersonalData>.Default.Equals(PersonalData, reservation.PersonalData) &&
                   EqualityComparer<Tuple<int, int>>.Default.Equals(Seat, reservation.Seat) &&
                   EqualityComparer<Show>.Default.Equals(Show, reservation.Show);
        }

        public override string ToString()
        {
            return "ID: " + ID + Environment.NewLine +
                   "Film: " + Show.Movie.Title + Environment.NewLine +
                   "Seans: " + Show.ID + Environment.NewLine +
                   "Data: " + Show.Date + Environment.NewLine +
                   "Miejsce: " + Seat.Item1 + " rząd, " + Seat.Item2 + " miejsce" + Environment.NewLine +
                   "Dane klienta: " + PersonalData + Environment.NewLine;
        }

        #endregion
    }
}
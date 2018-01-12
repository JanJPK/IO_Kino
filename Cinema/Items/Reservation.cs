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
            if (reservation == null)
                return false;

            if (Seat.Item1 != reservation.Seat.Item1)
                return false;

            if (Seat.Item2 != reservation.Seat.Item2)
                return false;

            return EqualityComparer<PersonalData>.Default.Equals(PersonalData, reservation.PersonalData) &&
                   Show.ID == reservation.Show.ID;
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
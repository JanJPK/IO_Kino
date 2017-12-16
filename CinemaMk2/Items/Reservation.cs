using System;
using System.Collections.Generic;

namespace CinemaMk2.Items
{
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

        public int ID { get; set; }
        public Tuple<int, int> Seat { get; set; }
        public PersonalData PersonalData { get; set; }
        public Show Show { get; set; }

        #endregion

        #region Public Methods and Operators

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
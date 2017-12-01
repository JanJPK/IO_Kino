using System;
using System.Collections.Generic;

namespace Cinema.Items
{
    public class Reservation : ICinemaItem
    {
        #region Constructors and Destructors

        public Reservation(int id, PersonalData personalData, Show show, Tuple<int, int> miejsce)
        {
            ID = id;
            PersonalData = personalData;
            Show = show;
            Miejsce = miejsce;
        }

        #endregion

        #region Public Properties

        public int ID { get; set; }
        public Tuple<int, int> Miejsce { get; set; }
        public PersonalData PersonalData { get; set; }
        public Show Show { get; set; }

        #endregion

        #region Public Methods and Operators

        public override bool Equals(object obj)
        {
            var rezerwacja = obj as Reservation;
            return rezerwacja != null &&
                   ID == rezerwacja.ID &&
                   EqualityComparer<PersonalData>.Default.Equals(PersonalData, rezerwacja.PersonalData) &&
                   EqualityComparer<Show>.Default.Equals(Show, rezerwacja.Show) &&
                   EqualityComparer<Tuple<int, int>>.Default.Equals(Miejsce, rezerwacja.Miejsce);
        }

        public override int GetHashCode()
        {
            var hashCode = 1640393673;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<PersonalData>.Default.GetHashCode(PersonalData);
            hashCode = hashCode * -1521134295 + EqualityComparer<Show>.Default.GetHashCode(Show);
            hashCode = hashCode * -1521134295 + EqualityComparer<Tuple<int, int>>.Default.GetHashCode(Miejsce);
            return hashCode;
        }

        public override string ToString()
        {
            return "ID: " + ID + Environment.NewLine +
                   "Movie: " + Show.Movie.Title + Environment.NewLine +
                   "Seans: " + Show.ID + Environment.NewLine +
                   "Data: " + Show.Date + Environment.NewLine +
                   "Miejsce: " + Miejsce.Item1 + " rząd, " + Miejsce.Item2 + " miejsce" + Environment.NewLine +
                   "Dane klienta: " + PersonalData + Environment.NewLine;
        }

        #endregion
    }
}
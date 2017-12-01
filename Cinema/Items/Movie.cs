using System;
using System.Collections.Generic;

namespace Cinema.Items
{
    public class Movie : ICinemaItem
    {
        #region Constructors and Destructors

        public Movie(int id, string title, DateTime releaseDate, int length, string director, int viewerAge,
            string language)
        {
            ID = id;
            Title = title;
            ReleaseDate = releaseDate;
            Length = length;
            Director = director;
            ViewerAge = viewerAge;
            Language = language;
        }

        #endregion

        #region Public Properties

        public string Director { get; set; }
        public int ID { get; set; }
        public string Language { get; set; }
        public int Length { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public int ViewerAge { get; set; }

        #endregion

        #region Public Methods and Operators

        public override bool Equals(object obj)
        {
            var film = obj as Movie;
            return film != null &&
                   ID == film.ID &&
                   Title == film.Title &&
                   ReleaseDate == film.ReleaseDate &&
                   Length == film.Length &&
                   Director == film.Director &&
                   ViewerAge == film.ViewerAge &&
                   Language == film.Language;
        }

        public override int GetHashCode()
        {
            var hashCode = 1109788431;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + ReleaseDate.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Director);
            hashCode = hashCode * -1521134295 + ViewerAge.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Language);
            return hashCode;
        }

        public override string ToString()
        {
            return "ID: " + ID + Environment.NewLine +
                   "Tytuł: " + Title + Environment.NewLine +
                   "Premiera: " + ReleaseDate + Environment.NewLine +
                   "Długość: " + Length + " minut" + Environment.NewLine +
                   "Reżyser: " + Director + Environment.NewLine +
                   "Sugerowany wiek: " + ViewerAge + Environment.NewLine +
                   "Język: " + Language + Environment.NewLine;
        }

        #endregion
    }
}
using System;

namespace Cinema.Items
{
    /// <summary>
    ///     Film.
    /// </summary>
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

        public Movie(Movie movie)
        {
            ID = movie.ID;
            Title = movie.Title;
            ReleaseDate = movie.ReleaseDate;
            Length = movie.Length;
            Director = movie.Director;
            ViewerAge = movie.ViewerAge;
            Language = movie.Language;
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

        public override string ToString()
        {
            return "ID: " + ID + Environment.NewLine +
                   "Tytuł: " + Title + Environment.NewLine +
                   "Premiera: " + ReleaseDate.ToString("yyyy-MM-dd") + Environment.NewLine +
                   "Długość: " + Length + " minut" + Environment.NewLine +
                   "Reżyser: " + Director + Environment.NewLine +
                   "Sugerowany wiek: " + ViewerAge + Environment.NewLine +
                   "Język: " + Language + Environment.NewLine;
        }

        #endregion
    }
}
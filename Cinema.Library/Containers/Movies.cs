using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Library.Items;

namespace Cinema.Library.Containers
{
    /// <summary>
    ///     Kontener filmów.
    /// </summary>
    public class Movies : ContainerBase<Movie>
    {
        #region Constructors and Destructors

        public Movies()
        {
            Items = new Dictionary<int, Movie>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Dodaje nowy film. ID jest generowane automatycznie.
        /// </summary>
        /// <param name="title">Tytuł filmu.</param>
        /// <param name="releaseDate">Data premiery.</param>
        /// <param name="length">Długość w minutach</param>
        /// <param name="director">Reżyser.</param>
        /// <param name="viewerAge">Sugerowany wiek widza.</param>
        /// <param name="language">Język.</param>
        /// <returns>Utworzony film lub null jeżeli się nie udało.</returns>
        public Movie Add(string title, DateTime releaseDate, int length, string director, int viewerAge,
            string language)
        {
            // Sprawdzenie czy film o takim tytule nie jest już w bazie.
            if (Search(title) != null) return null;

            //int id = Items.OrderBy(p => p.ID).Last().ID;
            int id = Items.Count == 0 ? 0 : Items.Keys.Max();
            id++;

            var movie = new Movie(id, title, releaseDate, length, director, viewerAge, language);

            if (Items.ContainsValue(movie)) return null;

            Items.Add(id, movie);
            return movie;
        }

        /// <summary>
        ///     Znajduje film o zadanym tytule.
        /// </summary>
        /// <param name="title">Tytuł filmu.</param>
        /// <returns>Film lub null gdy nie ma takiego filmu.</returns>
        public Movie Search(string title)
        {
            //return Items.First(p => p.Title == title);
            return Items.FirstOrDefault(x => x.Value.Title == title).Value;
        }

        #endregion
    }
}
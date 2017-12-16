using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Items;

namespace Cinema.Containers
{
    public class Movies : ContainerBase<Movie>
    {
        #region Constructors and Destructors

        public Movies()
        {
            Items = new Dictionary<int, Movie>();
        }

        #endregion

        #region Public Methods and Operators

        public Movie Add(string title, DateTime releaseDate, int length, string director, int viewerAge,
            string language)
        {
            //int id = Items.OrderBy(p => p.ID).Last().ID;
            int id = Items.Count == 0 ? 0 : Items.Keys.Max();
            id++;

            Movie movie = new Movie(id, title, releaseDate, length, director, viewerAge, language);
            if (!Items.ContainsValue(movie))
            {
                Items.Add(id, movie);
                return movie;
            }
            return null;
        }

        public Movie Search(string title)
        {
            //return Items.First(p => p.Title == title);
            return Items.FirstOrDefault(x => x.Value.Title == title).Value;
        }

        #endregion
    }
}
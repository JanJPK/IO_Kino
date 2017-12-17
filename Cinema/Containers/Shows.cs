using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Items;

namespace Cinema.Containers
{
    public class Shows : ContainerBase<Show>
    {
        #region Constructors and Destructors

        public Shows()
        {
            Items = new Dictionary<int, Show>();
        }

        #endregion

        #region Public Methods and Operators

        public Show Add(DateTime date, int length, decimal ticketPrice, Movie movie)
        {
            int id = Items.Count == 0 ? 0 : Items.Keys.Max();
            id++;

            var show = new Show(id, date, length, ticketPrice, movie);
            if (!Items.ContainsValue(show))
            {
                Items.Add(id, show);
                return show;
            }
            return null;
        }

        public List<string> PlannedShows(DateTime date)
        {
            var query = from item in Items
                where item.Value.Date.Date == date.Date
                select item;
            if (query.Any())
            {
                List<string> showTimes = new List<string>();
                showTimes.Add("Zaplanowane seanse:");
                foreach (var item in query)
                {
                    showTimes.Add(item.Value.Date.TimeOfDay + " - " +
                                  item.Value.Date.AddMinutes(item.Value.Length).TimeOfDay);
                }
                return showTimes;
            }

            return null;
        }

        public void Remove(string title)
        {
            for (int i = Items.Count; i > 0; i--)
            {
                if (Items[i].Movie.Title == title)
                {
                    Items.Remove(i);
                }
            }

        }

        public Show Search(DateTime date)
        {
            return Items.FirstOrDefault(x => x.Value.Date == date).Value;
        }

        public List<Show> Search(string title)
        {
            List<Show> shows = new List<Show>();
            foreach (var item in Items)
            {
                if (item.Value.Movie.Title == title)
                {
                    shows.Add(item.Value);
                }
            }
            return shows;
        }

        #endregion
    }
}
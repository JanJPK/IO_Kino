using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.System.Items;

namespace Cinema.System.Containers
{
    /// <summary>
    ///     Kontener seansów.
    /// </summary>
    public class Shows : ContainerBase<Show>
    {
        #region Constructors and Destructors

        public Shows()
        {
            Items = new Dictionary<int, Show>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Dodaje nowy seans. ID jest generowane automatycznie.
        /// </summary>
        /// <param name="date">Data.</param>
        /// <param name="length">Długość w minutach.</param>
        /// <param name="ticketPrice">Cena biletu.</param>
        /// <param name="movie">Film.</param>
        /// <returns>Utworzony seans lub null jeżeli się nie udało.</returns>
        public Show Add(DateTime date, int length, decimal ticketPrice, Movie movie)
        {
            int id = Items.Count == 0 ? 0 : Items.Keys.Max();
            id++;

            var show = new Show(id, date, length, ticketPrice, movie);

            if (Items.ContainsValue(show)) return null;

            Items.Add(id, show);
            return show;
        }

        /// <summary>
        ///     ! NIESKOŃCZONE ! NIETESTOWANE !
        ///     Zwraca przedziały czasu w których są seanse - można zobaczyć kiedy sala jest zajęta.
        /// </summary>
        /// <param name="date">Zadany dzień.</param>
        /// <returns>Lista czasów.</returns>
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

        /// <summary>
        ///     Usuwa wszystkie seanse dla zadanego filmu.
        /// </summary>
        /// <param name="title">Tytuł filmu.</param>
        public bool Remove(string title)
        {
            List<int> keysToRemove = new List<int>();
            bool removedAny = false;

            foreach (var item in Items)
            {
                if (item.Value.Movie.Title == title)
                    keysToRemove.Add(item.Key);
            }

            foreach (var key in keysToRemove)
            {
                Items.Remove(key);
                removedAny = true;
            }

            return removedAny;
        }

        /// <summary>
        ///     Znajduje seans o danej godzinie.
        /// </summary>
        /// <param name="date">Data/godzina seansu.</param>
        /// <returns>Seans lub null gdy nie ma takiego.</returns>
        public Show Search(DateTime date)
        {
            return Items.FirstOrDefault(x => x.Value.Date == date).Value;
        }

        /// <summary>
        ///     Znajduje seanse danego filmu.
        /// </summary>
        /// <param name="title">Tytuł filmu.</param>
        /// <returns>Lista znalezionych seansów.</returns>
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
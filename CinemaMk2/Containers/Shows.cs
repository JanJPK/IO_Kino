using System;
using System.Collections.Generic;
using System.Linq;
using CinemaMk2.Items;

namespace CinemaMk2.Containers
{
    public class Shows : ContainerBase<Show>
    {
        public Shows()
        {
            Items = new Dictionary<int, Show>();
        }

        public Show Add(string title, DateTime date, int length, float ticketPrice, Movie movie)
        {
            int id = Items.Keys.Max();
            id++;
            var show = new Show(id, date, length, ticketPrice, movie);
            if (!Items.ContainsValue(show))
            {
                Items.Add(id, show);
                return show;
            }
            return null;
        }

        public Show Search(DateTime date)
        {
            return Items.FirstOrDefault(x => x.Value.Date == date).Value;
        }
    }
}

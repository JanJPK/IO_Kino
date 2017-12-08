using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Items;

namespace Cinema.Containers
{
    public class Shows : ContainerBase<Show>
    {
        protected override Dictionary<int, Show> Items { get; set; }

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

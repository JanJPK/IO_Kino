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
        public override Dictionary<int, Show> Items { get; set; }

        public void Add(string title, DateTime date, int length, float ticketPrice, Movie movie)
        {
            int id = Items.Keys.Max();
            id++;
            Items.Add(id, new Show(id, date, length, ticketPrice, movie));
        }

        public Show Search(DateTime date)
        {
            return Items.FirstOrDefault(x => x.Value.Date == date).Value;
        }
    }
}

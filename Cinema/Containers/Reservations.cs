using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Items;

namespace Cinema.Containers
{
    class Reservations : ContainerBase<Reservation>
    {
        protected override Dictionary<int, Reservation> Items { get; set; }
    }
}

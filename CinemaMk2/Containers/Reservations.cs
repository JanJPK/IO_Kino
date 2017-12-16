using System;
using System.Collections.Generic;
using System.Linq;
using CinemaMk2.Items;

namespace CinemaMk2.Containers
{
    public class Reservations : ContainerBase<Reservation>
    {

        public Reservations()
        {
            Items = new Dictionary<int, Reservation>();
        }

        public bool Add(int showId, PersonalData personalData, Show show, Tuple<int, int> miejsce)
        {
            int id = Items.Count;
            id = showId * 10 + id;
            var reservation = new Reservation(id, personalData, show, miejsce);
            if (!Items.ContainsValue(reservation))
            {
                Items.Add(id, reservation);
                return true;
            }
            return false;
        }
    }
}

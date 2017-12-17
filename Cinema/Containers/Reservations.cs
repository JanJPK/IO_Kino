using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Items;

namespace Cinema.Containers
{
    public class Reservations : ContainerBase<Reservation>
    {
        #region Constructors and Destructors

        public Reservations()
        {
            Items = new Dictionary<int, Reservation>();
        }

        #endregion

        #region Public Methods and Operators

        public Reservation Add(PersonalData personalData, Show show, Tuple<int, int> seat)
        {
            // ID rezerwacji = SRRR
            //      S - ID seansu
            //      RRR - ID rezerwacji
            int id = Items.Count == 0 ? 1 : Items.Keys.Max();
            id++;
            id += show.ID * 100;

            var reservation = new Reservation(id, personalData, show, seat);
            if (!Items.ContainsValue(reservation) && show.Seats[seat.Item1, seat.Item2] == false)
            {
                Items.Add(id, reservation);
                show.Seats[seat.Item1, seat.Item2] = true;
                return reservation;
            }
            return null;
        }

        public override bool Remove(int id)
        {
            Reservation reservation = Search(id);
            if (reservation != null)
            {
                // Zwalnianie miejsca.
                reservation.Show.Seats[reservation.Seat.Item1, reservation.Seat.Item2] = false;
                // Usuwanie.
                Items.Remove(id);
                return true;
            }
            return false;
        }

        public List<Reservation> Search(string phone)
        {
            List<Reservation> reservations = new List<Reservation>();
            foreach (var item in Items)
            {
                if (item.Value.PersonalData.Phone == phone)
                {
                    reservations.Add(item.Value);
                }
            }
            return reservations;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.System.Items;

namespace Cinema.System.Containers
{
    /// <summary>
    ///     Kontener rezerwacji.
    /// </summary>
    public class Reservations : ContainerBase<Reservation>
    {
        #region Constructors and Destructors

        public Reservations()
        {
            Items = new Dictionary<int, Reservation>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Dodaje nową rezerwacje. ID jest generowane automatycznie.
        /// </summary>
        /// <param name="personalData">Dane klienta.</param>
        /// <param name="show">Seans.</param>
        /// <param name="seat">Miejsce w sali.</param>
        /// <returns>Utworzoną rezerwację lub null jeżeli się nie udało.</returns>
        public Reservation Add(PersonalData personalData, Show show, Tuple<int, int> seat)
        {
            bool IsSeatAvailable() => 
                 !show.Seats[seat.Item1, seat.Item2];

            // Sprawdzenie czy miejsce jest wolne.
            //if (show.Seats[seat.Item1, seat.Item2]) return null;
            if (!IsSeatAvailable()) return null;

            // ID rezerwacji = SRRR
            //      S - ID seansu
            //      RRR - ID rezerwacji
            int id = Items.Count == 0 ? 0 : Items.Keys.Max();
            id++;
            id += show.ID * 100;

            var reservation = new Reservation(id, personalData, show, seat);

            Items.Add(id, reservation);
            show.Seats[seat.Item1, seat.Item2] = true;
            return reservation;
        }

        /// <summary>
        ///     Usuwanie rezerwacji o zadanym ID.
        /// </summary>
        /// <param name="id">ID rezerwacji.</param>
        /// <returns>Prawda gdy rezerwacja została pomyślnie usunięta.</returns>
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

        /// <summary>
        ///     Znajduje rezerwację na dany numer telefonu.
        /// </summary>
        /// <param name="phone">Numer telefonu.</param>
        /// <returns>Lista znalezionych rezerwacji lub null gdy ich nie ma.</returns>
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
using System;
using System.Text;
using Cinema.System.Containers;

namespace Cinema.System.Items
{
    /// <summary>
    ///     Seans. Zawiera film (Movie) oraz kontener rezerwacji (Reservations).
    /// </summary>
    public class Show : ICinemaItem
    {
        #region Constructors and Destructors

        public Show(int id, DateTime date, int length, decimal ticketPrice, Movie movie)
        {
            ID = id;
            Date = date;
            Length = length;
            TicketPrice = ticketPrice;
            Movie = movie;
            Reservations = new Reservations();
            Seats = new bool[8, 8];
        }

        #endregion

        #region Public Properties

        public DateTime Date { get; set; }
        public int ID { get; }
        public int Length { get; set; }
        public Movie Movie { get; set; }
        public Reservations Reservations { get; set; }
        public bool[,] Seats { get; set; }
        public decimal TicketPrice { get; set; }

        #endregion

        #region Public Methods and Operators

        public Reservation AddReservation(PersonalData personalData, Tuple<int, int> seat)
        {
            return Reservations.Add(personalData, this, seat);
        }

        public override bool Equals(object obj)
        {
            var show = obj as Show;
            if (show == null)
                return false;

            if (Seats.GetLength(0) != show.Seats.GetLength(0))
                return false;
            if (Seats.GetLength(1) != show.Seats.GetLength(1))
                return false;

            for (int i = 0; i < Seats.GetLength(0); i++)
            {
                for (int j = 0; j < Seats.GetLength(1); j++)
                {
                    if (Seats[i, j] != show.Seats[i, j])
                        return false;
                }
            }

            return Date == show.Date &&
                   ID == show.ID &&
                   Length == show.Length &&
                   Movie.Equals(show.Movie) &&
                   Reservations.Equals(show.Reservations) &&
                   TicketPrice == show.TicketPrice;
        }

        public string ShowSeats()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("       --[EKRAN]--" + Environment.NewLine);
            sb.Append(" ");
            for (int i = 0; i < Seats.GetLength(1); i++)
            {
                sb.Append(" " + (i + 1) + " ");
            }
            sb.Append(Environment.NewLine);
            for (int i = 0; i < Seats.GetLength(0); i++)
            {
                sb.Append(i + 1);
                for (int j = 0; j < Seats.GetLength(1); j++)
                {
                    sb.Append(Seats[i, j] ? "[R]" : "[_]");
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return "ID: " + ID + Environment.NewLine +
                   "Film: " + Movie.Title + Environment.NewLine +
                   "Długość: " + Length + Environment.NewLine +
                   "Data: " + Date.ToString("yyyy-MM-dd HH:mm") + Environment.NewLine +
                   "Cena biletu: " + TicketPrice + Environment.NewLine +
                   "Ilość rezerwacji: " + CountOccupiedSeats() + "/" + Seats.Length + Environment.NewLine;
        }

        #endregion

        #region Methods

        private int CountOccupiedSeats()
        {
            int occupiedSeats = 0;
            for (int i = 0; i < Seats.GetLength(0); i++)
            {
                for (int j = 0; j < Seats.GetLength(1); j++)
                {
                    if (Seats[i, j])
                        occupiedSeats++;
                }
            }
            return occupiedSeats;
        }

        #endregion
    }
}
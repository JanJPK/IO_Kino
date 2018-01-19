using System;
using System.Collections.Generic;
using System.Linq;
using fit;

namespace Cinema.Library
{
    public class FitnesseTest : ColumnFixture
    {
        #region Add

        public int AddInt1;
        public int AddInt2;

        public int Add()
        {
            return AddInt1 + AddInt2;
        }

        #endregion

        #region Concat

        public string ConcatString1;
        public string ConcatString2;

        public string Concat()
        {
            return ConcatString1 + " " + ConcatString2;
        }

        #endregion

        #region CheckSeat

        public int CheckSeatRow;
        public int CheckSeatColumn;

        public bool[,] Seats = new bool[3, 3]
        {
            {true, true, false}, 
            {true, true, false}, 
            {true, false, false}
        };

        public bool CheckSeat()
        {
            return Seats[CheckSeatRow, CheckSeatColumn];
        }

        #endregion

        #region AddToList

        public int ReservationRow;
        public int ReservationColumn;
        public string ReservationName;

        public List<string> Reservations = new List<string>();

        public bool AddReservation()
        {
            if (ReservationRow < Seats.GetLength(0) && ReservationColumn < Seats.GetLength(1))
            {
                if (Seats[ReservationRow, ReservationColumn] == false)
                {
                    Reservations.Add(ReservationName);
                    Seats[ReservationRow, ReservationColumn] = true;
                    return true;
                }
            }
            return false;
        }

        public int ReservationCount()
        {
            return Reservations.Count;
        }

        public string LastReservation()
        {
            if (Reservations.Count == 0)
                return null;
            return Reservations.Last();
        }

        #endregion

    }
}
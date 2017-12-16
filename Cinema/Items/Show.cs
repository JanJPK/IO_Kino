﻿using System;
using Cinema.Containers;

namespace Cinema.Items
{
    public class Show : ICinemaItem
    {
        public Reservations Reservations { get; set; }
        #region Constructors and Destructors

        public Show(int id, DateTime date, int length, decimal ticketPrice, Movie movie)
        {
            ID = id;
            Date = date;
            Length = length;
            TicketPrice = ticketPrice;
            Movie = movie;
            Reservations = new Reservations();
            Seats = new bool[10,8];
        }

        #endregion

        #region Public Properties

        public DateTime Date { get; set; }
        public int ID { get; set; }
        public int Length { get; set; }
        public Movie Movie { get; set; }
        public bool[,] Seats { get; set; }
        public decimal TicketPrice { get; set; }

        #endregion

        #region Public Methods and Operators

        public override string ToString()
        {
            return "ID: " + ID + Environment.NewLine +
                   "Film: " + Movie.Title + Environment.NewLine +
                   "Długość: " + Length + Environment.NewLine +
                   "Data: " + Date + Environment.NewLine +
                   "Cena biletu: " + TicketPrice + Environment.NewLine +
                   "Ilość miejsc: " + Seats.Length + Environment.NewLine;
        }

        #endregion
    }
}
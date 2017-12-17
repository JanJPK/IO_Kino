using System;
using Cinema.Containers;
using Cinema.Items;

namespace Cinema
{
    public class CinemaSystem
    {
        #region Fields

        private readonly Movies movies;
        private readonly Shows shows;

        // Inwentarz sklepu z filmami.
        private Movie[] movieStoreInventory =
        {
            new Movie(0, "Kwaśny robaczek", Convert.ToDateTime("2009-05-26"),
                125, "M. Shamalayamanam", 19, "Polski"),
            new Movie(0, "Kwaśny robaczek 2: Zemsta", Convert.ToDateTime("2013-09-21"),
                145, "M. Shamalayamanam", 19, "Polski"),
            new Movie(0, "Kwaśny robaczek 3: Powrót robaczka", Convert.ToDateTime("2017-11-15"),
                186, "K. Shakashsahamasan", 19, "Polski")
        };

        #endregion

        #region Constructors and Destructors

        public CinemaSystem()
        {
            movies = new Movies();
            shows = new Shows();
            PopulateContainers();
        }

        #endregion

        #region Public Methods and Operators

        public void Run()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Główne menu: ");
                Console.WriteLine("1 - Filmy");
                Console.WriteLine("2 - Seanse");
                Console.WriteLine("3 - Rezerwacje");
                Console.WriteLine("4 - Bilety");
                Console.WriteLine("5 - Koniec");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawna liczba.");
                        break;
                    }

                    case '1':
                    {
                        MenuMovie();
                        break;
                    }

                    case '2':
                    {
                        MenuShow();
                        break;
                    }

                    case '3':
                    {
                        MenuReservation();
                        break;
                    }

                    case '4':
                    {
                        MenuTicket();
                        break;
                    }

                    case '5':
                    {
                        stop = true;
                        break;
                    }
                }
            }
        }

        #endregion

        #region Methods

        private void AddMovie()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Podaj reżysera: ");
            string director = Console.ReadLine();
            Console.WriteLine("Podaj język: ");
            string language = Console.ReadLine();
            Console.WriteLine("Podaj długość:");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj datę premiery [yyyy-MM-dd]: ");
            DateTime releaseDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Podaj tytuł: ");
            string title = Console.ReadLine();
            Console.WriteLine("Podaj sugerowany wiek");
            int viewerAge = Convert.ToInt32(Console.ReadLine());

            var movie = movies.Add(title, releaseDate, length, director, viewerAge, language);
            Console.WriteLine(movie != null ? "Dodawanie powiodło się." : "Dodawanie nie powiodło sie.");
        }

        private void AddReservation()
        {
            var show = FindShow();
            if (show != null)
            {
                //(PersonalData personalData, Show show, Tuple<int, int> seat)
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Podaj dane osobowe rezerwującego: ");
                Console.WriteLine("Imię: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Nazwisko: ");
                string secondName = Console.ReadLine();
                Console.WriteLine("Nr telefonu: ");
                string phone = Console.ReadLine();

                int row = 0;
                int column = 0;
                while (true)
                {
                    Console.WriteLine(show.ShowSeats());
                    Console.WriteLine("Wybierz rząd: ");
                    row = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Wybierz miejsce: ");
                    column = Convert.ToInt32(Console.ReadLine());

                    if (!show.Seats[row, column])
                        break;
                    Console.Write("Miejsce jest zajęte. Wybierz inne.");
                }


                var reservation = show.AddReservation(new PersonalData(firstName, secondName, phone),
                    new Tuple<int, int>(row - 1, column - 1));
                Console.WriteLine(reservation != null ? "Dodawanie powiodło się." : "Dodawanie nie powiodło sie.");
            }
        }

        private void AddShow()
        {
            Console.WriteLine("Podaj datę seansu [yyyy-MM-dd HH:mm]:");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Podaj długość seansu: ");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj koszt biletów: ");
            decimal ticketPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Wybierz film: ");
            Movie movie = FindMovie();
            if (movie != null)
            {
                var show = shows.Add(date, length, ticketPrice, movie);
                Console.WriteLine(show != null ? "Dodawanie powiodło się." : "Dodawanie nie powiodło sie.");
            }
        }

        private Movie FindMovie()
        {
            if (movies.Any())
            {
                Console.WriteLine("Tryb wyszukiwania filmu: ");
                Console.WriteLine("1 - Po ID");
                Console.WriteLine("2 - Po tytule");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawna liczba. Zwracam null.");
                        break;
                    }

                    case '1':
                    {
                        Console.WriteLine("Podaj ID: ");
                        var input = Console.ReadLine();
                        var movie = movies.Search(Convert.ToInt32(input));
                        if (movie != null) return movie;
                        break;
                    }

                    case '2':
                    {
                        Console.WriteLine("Podaj tytuł: ");
                        var input = Console.ReadLine();
                        var movie = movies.Search(input);
                        if (movie != null) return movie;
                        break;
                    }
                }
                Console.WriteLine("Nie znaleziono takiego filmu.");
                return null;
            }
            Console.WriteLine("Baza filmów jest pusta!");
            return null;
        }

        private Reservation FindReservation(int showID)
        {
            if (shows.Items[showID].Reservations.Any())
            {
                Console.WriteLine("Tryb wyszukiwania rezerwacji: ");
                Console.WriteLine("1 - Po ID");
                Console.WriteLine("2 - Po nr telefonu");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawna liczba. Zwracam null.");
                        break;
                    }

                    case '1':
                    {
                        Console.WriteLine("Podaj ID: ");
                        var input = Console.ReadLine();
                        var reservation = shows.Items[showID].Reservations.Search(Convert.ToInt32(input));
                        if (reservation != null) return reservation;
                        break;
                    }

                    case '2':
                    {
                        Console.WriteLine("Podaj nr telefonu: ");
                        var input = Console.ReadLine();
                        var foundReservations = shows.Items[showID].Reservations.Search(input);
                        if (foundReservations.Count > 0)
                        {
                            for (int i = 0; i < foundReservations.Count; i++)
                            {
                                Console.WriteLine((i + 1) + "- ID: " + foundReservations[i].ID + "; film: " +
                                                  foundReservations[i].Show.Movie.Title + "; data: " +
                                                  foundReservations[i].Show.Date);
                            }
                            Console.WriteLine("Wybierz rezerwacje: ");
                            var reservationID = (int) char.GetNumericValue(Console.ReadKey().KeyChar);
                            Console.WriteLine(Environment.NewLine);
                            return foundReservations[reservationID - 1];
                        }
                        break;
                    }
                }
                Console.WriteLine("Nie znaleziono takiej rezerwacji.");
                return null;
            }
            Console.WriteLine("Nie ma rezerwacji na dany seans!");
            return null;
        }

        private Show FindShow()
        {
            if (shows.Any())
            {
                Console.WriteLine("Tryb wyszukiwania seansu: ");
                Console.WriteLine("1 - Po ID");
                Console.WriteLine("2 - Po tytule filmu");
                Console.WriteLine("3 - Po dacie");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawna liczba. Zwracam null.");
                        break;
                    }

                    case '1':
                    {
                        Console.WriteLine("Podaj ID: ");
                        var input = Console.ReadLine();
                        var show = shows.Search(Convert.ToInt32(input));
                        if (show != null) return show;
                        break;
                    }

                    case '2':
                    {
                        Console.WriteLine("Podaj tytuł filmu: ");
                        var input = Console.ReadLine();
                        var foundShows = shows.Search(input);
                        if (foundShows.Count > 0)
                        {
                            for (int i = 0; i < foundShows.Count; i++)
                            {
                                Console.WriteLine(i + " - ID: " + foundShows[i].ID + "; data: " + foundShows[i].Date);
                            }
                            Console.WriteLine("Wybierz seans: ");
                            var showID = (int) char.GetNumericValue(Console.ReadKey().KeyChar);
                            Console.WriteLine(Environment.NewLine);
                            return foundShows[showID];
                        }
                        break;
                    }

                    case '3':
                    {
                        Console.WriteLine("Podaj datę: ");
                        var input = Console.ReadLine();
                        var show = shows.Search(Convert.ToDateTime(input));
                        if (show != null) return show;
                        break;
                    }
                }
                Console.WriteLine("Nie znaleziono takiego seansu.");
                return null;
            }
            Console.WriteLine("Baza seansów jest pusta!");
            return null;
        }

        private void MenuMovie()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Menu filmów");
                Console.WriteLine("1 - Dodaj film");
                Console.WriteLine("2 - Usuń film");
                Console.WriteLine("3 - Modyfikuj film");
                Console.WriteLine("4 - Lista filmów");
                Console.WriteLine("5 - Powrót");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawna liczba.");
                        break;
                    }

                    case '1':
                    {
                        AddMovie();
                        break;
                    }

                    case '2':
                    {
                        RemoveMovie();
                        break;
                    }

                    case '3':
                    {
                        ModifyMovie();
                        break;
                    }

                    case '4':
                    {
                        foreach (var movie in movies.Items)
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.Write(movie.Value);
                        }
                        break;
                    }

                    case '5':
                    {
                        stop = true;
                        break;
                    }
                }
            }
        }

        private void MenuReservation()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Menu rezerwacji");
                Console.WriteLine("1 - Dodaj rezerwacje");
                Console.WriteLine("2 - Usuń rezerwacje");
                Console.WriteLine("3 - Modyfikuj rezerwacje");
                Console.WriteLine("5 - Powrót");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawna liczba.");
                        break;
                    }

                    case '1':
                    {
                        AddReservation();
                        break;
                    }

                    case '2':
                    {
                        RemoveReservation();
                        break;
                    }

                    case '3':
                    {
                        ModifyReservation();
                        break;
                    }

                    case '5':
                    {
                        stop = true;
                        break;
                    }
                }
            }
        }

        private void MenuShow()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Menu seansów");
                Console.WriteLine("1 - Dodaj seans");
                Console.WriteLine("2 - Usuń seans");
                Console.WriteLine("3 - Modyfikuj seans");
                Console.WriteLine("4 - Lista seansów");
                Console.WriteLine("5 - Powrót");
                Console.WriteLine("6 - Podgląd miejsc");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawna liczba.");
                        break;
                    }

                    case '1':
                    {
                        AddShow();
                        break;
                    }

                    case '2':
                    {
                        RemoveShow();
                        break;
                    }

                    case '3':
                    {
                        ModifyShow();
                        break;
                    }

                    case '4':
                    {
                        foreach (var show in shows.Items)
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.Write(show.Value);
                        }
                        break;
                    }

                    case '5':
                    {
                        stop = true;
                        break;
                    }

                    case '6':
                    {
                        var show = FindShow();
                        Console.Write(show != null ? show.ShowSeats() : "Błąd.");
                        break;
                    }
                }
            }
        }

        private void MenuTicket()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Menu biletów");
                Console.WriteLine("1 - Sprzedaj bilet");
                Console.WriteLine("5 - Powrót");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawna liczba.");
                        break;
                    }

                    case '1':
                    {
                        SellTicket();
                        break;
                    }

                    case '5':
                    {
                        stop = true;
                        break;
                    }
                }
            }
        }

        private void ModifyMovie()
        {
            throw new NotImplementedException();
        }

        private void ModifyReservation()
        {
            throw new NotImplementedException();
        }

        private void ModifyShow()
        {
        }

        private void PopulateContainers()
        {
            movies.Add("Noc żywych prowadzących", Convert.ToDateTime("1996-12-12"), 125, "Roman R.", 17,
                "Matematyczny");
            movies.Add("Dogłębna analiza", Convert.ToDateTime("2012-11-26"), 125, "Pedro", 19, "Polski");

            shows.Add(Convert.ToDateTime("2017-12-12 12:00"), 120, 15, movies.Items[1]);
            shows.Add(Convert.ToDateTime("2017-12-12 17:00"), 120, 15, movies.Items[1]);
            shows.Add(Convert.ToDateTime("2017-12-12 8:00"), 120, 15, movies.Items[2]);

            shows.Items[1].AddReservation(new PersonalData("Bogdan", "Bobek", "123456789"),
                new Tuple<int, int>(5, 6));
            shows.Items[1].AddReservation(new PersonalData("Zenon", "Ziemniak", "321654987"),
                new Tuple<int, int>(5, 7));
            shows.Items[1].AddReservation(new PersonalData("Klaudiusz", "Kalafior", "321632387"),
                new Tuple<int, int>(3, 4));
            shows.Items[1].AddReservation(new PersonalData("Piotr", "Pyra", "321365987"),
                new Tuple<int, int>(3, 5));
            shows.Items[1].AddReservation(new PersonalData("Bartek", "Brokół", "854654987"),
                new Tuple<int, int>(3, 6));
            shows.Items[2].AddReservation(new PersonalData("Bogdan", "Bobek", "123456789"),
                new Tuple<int, int>(7, 6));
        }

        private void PrintTicket(Reservations reservation)
        {
            Console.WriteLine("Wydrukowany bilet:");
            Console.Write(reservation.ToString());
        }

        private void RemoveMovie()
        {
            Console.WriteLine("Wybierz film do usunięcia");
            var movie = FindMovie();
            if (movie != null)
            {
                Console.Write(movie);
                Console.WriteLine("Czy chcesz usunąć ten film? T/N");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawny znak.");
                        break;
                    }

                    case 't':
                    {
                        // Usuwa wszystkie seanse danego filmu.
                        shows.Remove(movie.Title);
                        // Usuwa film.
                        movies.Remove(movie.ID);
                        Console.WriteLine("Film oraz seanse usunięte.");
                        break;
                    }

                    case 'n':
                    {
                        Console.WriteLine("Operacja przerwana.");
                        break;
                    }
                }
            }
        }

        private void RemoveReservation()
        {
            var show = FindShow();
            if (show != null)
            {
                var reservation = FindReservation(show.ID);
                if (reservation != null)
                {
                    Console.Write(reservation);
                    Console.WriteLine("Czy chcesz usunąć tą rezerwacje? T/N");
                    var key = Console.ReadKey();
                    Console.WriteLine(Environment.NewLine);
                    switch (key.KeyChar)
                    {
                        default:
                        {
                            Console.WriteLine("Niepoprawny znak.");
                            break;
                        }

                        case 't':
                        {
                            show.Reservations.Remove(reservation.ID);
                            Console.WriteLine("Rezerwacja usunięta.");
                            break;
                        }

                        case 'n':
                        {
                            Console.WriteLine("Operacja przerwana.");
                            break;
                        }
                    }
                }
            }
        }

        private void RemoveShow()
        {
            Console.WriteLine("Wybierz seans do usunięcia");
            var show = FindShow();
            if (show != null)
            {
                Console.Write(show);
                Console.WriteLine("Czy chcesz usunąć ten seans? T/N");
                var key = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                switch (key.KeyChar)
                {
                    default:
                    {
                        Console.WriteLine("Niepoprawny znak.");
                        break;
                    }

                    case 't':
                    {
                        shows.Remove(show.ID);
                        Console.WriteLine("Seans usunięty.");
                        break;
                    }

                    case 'n':
                    {
                        Console.WriteLine("Operacja przerwana.");
                        break;
                    }
                }
            }
        }

        private void SellTicket()
        {
        }

        #endregion
    }
}
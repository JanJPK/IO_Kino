using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Containers;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            CinemaSystem cinema = new CinemaSystem();
            cinema.Run();
        }
    }
}

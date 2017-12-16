using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CinemaMk2.Annotations;
using CinemaMk2.Containers;
using CinemaMk2.Items;

namespace CinemaMk2.ViewModels
{
    public class CinemaSystem : INotifyPropertyChanged
    {
        public Movie SelectedMovie { get; set; }
        public Show SelectedShow { get; set; }
        public Reservation SelectedReservation { get; set;}
         
        public List<LookupItem> MovieLookup { get; set; }
        public List<LookupItem> ShowLookup { get; set; }
        public List<LookupItem> ReservationLookup { get; set; }

        private Movies Movies { get; set; }
        private Shows Shows { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnOpenMovieDetailView(int id)
        {
            SelectedMovie = Movies.Items[id];
        }

        public void OnOpenShowDetailView(int id)
        {
            SelectedShow = Shows.Items[id];
        }

        public void OnOpenReservationDetailView(int id)
        {
            SelectedReservation = SelectedShow.Reservations[id];
        }
    }
}

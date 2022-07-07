using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public class Cinema
    {
        private readonly Reservations reservations;
        private readonly Seances seances;

        public Cinema()
        {
            reservations = new Reservations();
            seances = new Seances();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return reservations.GetAllReservations();
        }

        public int GetReservationsCount()
        {
            return reservations.GetReservationsCount();
        }

        public bool MakeReservation(Reservation reservation)
        {
            return reservations.AddReservation(reservation);
        }

        public IEnumerable<Seance> GetAllSeances()
        {
            return seances.GetAllSeances();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using CRUD.Services.ReservationCreators;
using CRUD.Services.ReservationProviders;

namespace CRUD.Models
{
    public class Cinema
    {
        private readonly Reservations reservations;
        private readonly Seances seances;
        private readonly Halls halls;

        public Cinema(Reservations _reservations)
        {
            reservations = _reservations;
            seances = new Seances();
            halls = new Halls();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await reservations.GetAllReservations();
        }

        public int GetReservationsCount()
        {
            return reservations.GetReservationsCount();
        }

        public async Task MakeReservation(Reservation reservation)
        {
            await reservations.AddReservation(reservation);
        }

        public IEnumerable<Seance> GetAllSeances()
        {
            return seances.GetAllSeances();
        }
    }
}

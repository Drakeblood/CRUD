using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUD.Services.ReservationCreators;
using CRUD.Services.ReservationProviders;

namespace CRUD.Models
{
    public struct Reservation
    {
        public long id;
        public long id_seance;
        public int seatNumber;
        public DateTime reservationTime;
    }

    public class Reservations
    {
        private readonly IReservationCreator reservationCreator;
        private readonly IReservationProvider reservationProvider;

        private readonly List<Reservation> reservations;

        public Reservations(IReservationCreator _reservationCreator, IReservationProvider _reservationProvider)
        {
            reservations = new List<Reservation>();
            reservationCreator = _reservationCreator;
            reservationProvider = _reservationProvider;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await reservationProvider.GetAllReservations();
        }

        public int GetReservationsCount()
        {
            return reservations.Count;
        }

        public async Task AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in reservations)
            {
                if (existingReservation.id_seance == reservation.id_seance)
                {
                    if(existingReservation.seatNumber == reservation.seatNumber)
                    {
                        throw new Exception();
                    }
                }
            }
            await reservationCreator.CreateReservation(reservation);
        }
    }
}

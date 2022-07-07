using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public struct Reservation
    {
        public long id;
        public long id_seance;
        public int seatNumber;
        public DateTime reservationTime;
    }

    class Reservations
    {
        private readonly List<Reservation> reservations;

        public Reservations()
        {
            reservations = new List<Reservation>();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return reservations;
        }

        public int GetReservationsCount()
        {
            return reservations.Count;
        }

        public bool AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in reservations)
            {
                if (existingReservation.id_seance == reservation.id_seance)
                {
                    if(existingReservation.seatNumber != reservation.seatNumber)
                    {
                        reservations.Add(reservation);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

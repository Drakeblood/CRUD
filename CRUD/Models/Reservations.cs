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
        DateTime reservationTime;
    }

    class Reservations
    {
        public List<Reservation> reservations;

        public Reservations()
        {
            reservations = new List<Reservation>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public struct Reservation
    {
        public long id;
        public long id_seance;
        public long id_client;
        public int seats_count;
        DateTime reservation_Time;
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

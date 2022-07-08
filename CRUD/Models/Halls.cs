using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public struct Hall
    {
        public long hall_number;
        public List<Seat> seats;
    }

    public struct Seat
    {
        public int number;
        public bool available;
    }

    public class Halls
    {
        public List<Hall> halls;

        public Halls()
        {
            halls = new List<Hall>();
        }
    }
}

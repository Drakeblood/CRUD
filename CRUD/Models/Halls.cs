using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public struct Hall
    {
        public int seatsCount;
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

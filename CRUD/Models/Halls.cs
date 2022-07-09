using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public struct Hall
    {
        public int seatsCount;
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

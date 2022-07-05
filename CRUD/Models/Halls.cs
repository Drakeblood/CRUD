using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public struct Hall
    {
        public long hall_number;
        public int seats_count;
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

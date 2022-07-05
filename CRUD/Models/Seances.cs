using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public struct Seance
    {
        public long id;
        public long id_movie;
        public int hall_number;
        public DateTime start_time;
    }

    public class Seances
    {
        public List<Seance> seances;

        public Seances()
        {
            seances = new List<Seance>();
        }
    }
}

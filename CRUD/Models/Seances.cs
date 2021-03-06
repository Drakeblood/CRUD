using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public struct Seance
    {
        public int id_movie;
        public int id_hall;
        public DateTime start_time;
    }

    public class Seances
    {
        private readonly List<Seance> seances;

        public Seances()
        {
            seances = new List<Seance>();
        }

        public IEnumerable<Seance> GetAllSeances()
        {
            return seances;
        }

        public bool AddSeance(Seance seance)
        {
            seances.Add(seance);
            return true;
        }
    }
}

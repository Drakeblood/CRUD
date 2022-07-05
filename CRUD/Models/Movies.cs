using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public enum MovieType
    {
        Thriller,
        Action,
        Horror,
        NONE
    }

    public struct Movie
    {
        public long id;
        public string title;
        public int duration;
        public int year;
        public string descripton;
    }

    public class Movies
    {
        public List<Movie> movies;

        public Movies()
        {
            movies = new List<Movie>();
        }
    }
}

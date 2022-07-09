using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Models
{
    public struct Movie
    {
        public string title;
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

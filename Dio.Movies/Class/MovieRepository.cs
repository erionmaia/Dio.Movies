using System;
using System.Collections.Generic;
using Dio.Movies.Interfaces;

namespace Dio.Movies
{
    public class MovieRepository : IRepository<Movie>
    {
        private List<Movie> listMovie = new List<Movie>();
        public void Update(int cod, Movie obj)
        {
            listMovie[cod] = obj;
        }
        public void Delete(int cod)
        {
            listMovie[cod].Delete();
        }
        public void Insert(Movie obj)
        {
            listMovie.Add(obj);
        }
        public List<Movie> List()
        {
            return listMovie;
        }
        public int NextCod()
        {
            return listMovie.Count;
        }
        public Movie ReturnByCod(int cod)
        {
            return listMovie[cod];
        }
    }
}
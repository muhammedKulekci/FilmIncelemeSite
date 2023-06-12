using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Abstarct;
using FilmIncelemeMvcProject.DataAccessLayer.Abstract;
using FilmIncelemeMvcProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.BusinessLayer.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public Movie GetById(int id)
        {
            return _movieDal.Get(x=>x.MovieId ==  id);
        }

        public List<Movie> GetList()
        {
            return _movieDal.List(x=>x.IsStatus==true);
        }

        public List<Movie> GetListByGenreId(int id)
        {
            return _movieDal.List(x => x.GenreId == id);
        }

        public void MovieAdd(Movie movie)
        {
            _movieDal.Insert(movie);
        }

        public void MovieDelete(Movie movie)
        {
           
            _movieDal.Update(movie);
        }

        public void MovieUpdate(Movie movie)
        {
            _movieDal.Update(movie);
        }
    }
}
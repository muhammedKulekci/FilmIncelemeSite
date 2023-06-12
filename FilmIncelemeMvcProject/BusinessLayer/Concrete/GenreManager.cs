using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Abstarct;
using FilmIncelemeMvcProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.BusinessLayer.Concrete
{
    public class GenreManager : IGenreService
    {
        IGenreDal _genreDal;

        public GenreManager(IGenreDal genredal)
        {
            _genreDal = genredal;
        }

        public void GenreAdd(Genre genre)
        {
            _genreDal.Insert(genre);
        }

        public void GenreDelete(Genre genre)
        {
            
            _genreDal.Update(genre);
        }

        public void GenreUpdate(Genre genre)
        {
            _genreDal.Update(genre);
        }

        public Genre GetById(int id)
        {
            return _genreDal.Get(x=>x.GenreId == id);
        }

        public List<Genre> GetList()
        {
            return _genreDal.List(x => x.IsStatus == true);
        }
    }
}
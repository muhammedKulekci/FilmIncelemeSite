using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmIncelemeMvcProject.BusinessLayer.Abstarct
{
    public interface IMovieService
    {
        List<Movie> GetList();
        List<Movie> GetListByGenreId(int id);
        void MovieAdd(Movie movie);
        void MovieDelete(Movie movie);
        void MovieUpdate(Movie movie);
        Movie GetById(int id);
    }
}

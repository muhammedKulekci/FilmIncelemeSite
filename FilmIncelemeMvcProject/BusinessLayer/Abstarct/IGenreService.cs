using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmIncelemeMvcProject.BusinessLayer.Abstarct
{
    public interface IGenreService
    {
        List<Genre> GetList();
        void GenreAdd(Genre genre);
        Genre GetById(int id);
        void GenreDelete(Genre genre);
        void GenreUpdate(Genre genre);
    }
}

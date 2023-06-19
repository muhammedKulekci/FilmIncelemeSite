using EntityLayer.Concrete;
using FilmIncelemeMvcProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmIncelemeMvcProject.BusinessLayer.Abstarct
{
    internal interface IFavoritesService
    {
        List<Favorites> GetList();
        List<Favorites> GetListByUserId(int id);
        void FavoritesAdd(Favorites favorites);
        Favorites GetById(int id);
        void FavoritesDelete(Favorites favorites);
        Favorites GetByUserAndMovie(int userId, int movieId);

    }
}

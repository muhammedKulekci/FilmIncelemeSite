using FilmIncelemeMvcProject.BusinessLayer.Abstarct;
using FilmIncelemeMvcProject.DataAccessLayer.Abstract;
using FilmIncelemeMvcProject.DataAccessLayer.EntityFramework;
using FilmIncelemeMvcProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.BusinessLayer.Concrete
{
    public class FavoritesManager : IFavoritesService
    {
        IFavoritesDal _favoritesDal;

        public FavoritesManager(IFavoritesDal favoritesDal)
        {
            _favoritesDal = favoritesDal;
        }

        public void FavoritesAdd(Favorites favorites)
        {
            _favoritesDal.Insert(favorites);
        }

        public void FavoritesDelete(Favorites favorites)
        {
            _favoritesDal.Delete(favorites);
        }

        public Favorites GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Favorites GetByUserAndMovie(int userId, int movieId)
        {
            return _favoritesDal.Get(x => x.UserId == userId && x.MovieId == movieId);
        }


        public List<Favorites> GetList()
        {
            return _favoritesDal.List();
        }

        public List<Favorites> GetListByUserId(int id)
        {
            return _favoritesDal.List(x => x.UserId == id );
        }

        
    }
}
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
    public class WishListManager : IWishListService
    {
        IWishListDal _wishlistDal;

        public WishListManager(IWishListDal wishlistDal)
        {
            _wishlistDal = wishlistDal;
        }

        public WishList GetById(int id)
        {
            throw new NotImplementedException();
        }

        public WishList GetByUserAndMovie(int userId, int movieId)
        {
            return _wishlistDal.Get(x => x.UserId == userId && x.MovieId == movieId);
        }

        public List<WishList> GetList()
        {
            return _wishlistDal.List();
        }

        public List<WishList> GetListByUserId(int id)
        {
            return _wishlistDal.List(x => x.UserId == id);
        }

        public void WishListAdd(WishList wishList)
        {
            _wishlistDal.Insert(wishList);
        }

        public void WishListDelete(WishList wishList)
        {
            _wishlistDal.Delete(wishList);
        }
    }
}
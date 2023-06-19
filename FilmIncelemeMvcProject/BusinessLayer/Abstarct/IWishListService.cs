using FilmIncelemeMvcProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmIncelemeMvcProject.BusinessLayer.Abstarct
{
    internal interface IWishListService
    {
        List<WishList> GetList();
        List<WishList> GetListByUserId(int id);
        void WishListAdd(WishList wishList);
        WishList GetById(int id);
        void WishListDelete(WishList wishList);
        WishList GetByUserAndMovie(int userId, int movieId);
    }
}

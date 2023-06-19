using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Concrete;
using FilmIncelemeMvcProject.DataAccessLayer.EntityFramework;
using FilmIncelemeMvcProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmIncelemeMvcProject.Controllers
{
    public class WishListController : Controller
    {
        WishListManager wm = new WishListManager(new EFWishListDal());
        UserManager um = new UserManager(new EFUserDal());
        MovieManager mm = new MovieManager(new EFMovieDal());

        public ActionResult Index()
        {
            string email = (string)Session["Email"];
            User userInfo = um.GetByEmail(email);
            var wishList = wm.GetListByUserId(userInfo.UserId);

            List<Movie> wishListMovies = new List<Movie>();

            foreach (var wish in wishList)
            {
                int movieId = (int)wish.MovieId;
                Movie movie = mm.GetById(movieId);

                if (movie != null)
                {
                    wishListMovies.Add(movie);
                }
            }

            return View(wishListMovies);
        }

        public ActionResult AddToWishList(int movieId)
        {
            string email = (string)Session["Email"];
            User user = um.GetByEmail(email);

            if (user != null)
            {
                bool isAlreadyAdded = IsMovieInWishList(user.UserId, movieId);

                if (!isAlreadyAdded)
                {
                    WishList wish = new WishList();
                    wish.MovieId = movieId;
                    wish.UserId = user.UserId;
                    wm.WishListAdd(wish);
                }
            }

            return RedirectToAction("Index", "WishList");
        }

        public bool IsMovieInWishList(int userId, int movieId)
        {
            return wm.GetListByUserId(userId).Any(w => w.MovieId == movieId);
        }

        public ActionResult RemoveFromWishList(int movieId)
        {
            string email = (string)Session["Email"];
            User user = um.GetByEmail(email);

            if (user != null)
            {
                WishList wish = wm.GetByUserAndMovie(user.UserId, movieId);

                if (wish != null)
                {
                    wm.WishListDelete(wish);
                }
            }

            return RedirectToAction("Index", "WishList");
        }
    }
}

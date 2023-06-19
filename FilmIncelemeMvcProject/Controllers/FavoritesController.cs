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
    public class FavoritesController : Controller
    {
        FavoritesManager fm = new FavoritesManager(new EFFavoritesDal());
        UserManager um = new UserManager(new EFUserDal());
        MovieManager mm = new MovieManager(new EFMovieDal());
        public ActionResult Index()
        {
            string email = (string)Session["Email"];
            User userInfo = um.GetByEmail(email);
            var favList = fm.GetListByUserId(userInfo.UserId);

            List<Movie> favoriteMovies = new List<Movie>();

            foreach (var favorite in favList)
            {

                int movieId = favorite.MovieId;
                Movie movie = mm.GetById(movieId);
                if (movie != null)
                {
                    favoriteMovies.Add(movie);
                }
            }

            return View(favoriteMovies);
        }
        public ActionResult AddToFavorites(int movieId)
        {
           
                string email = (string)Session["Email"];
                User user = um.GetByEmail(email);

                if (user != null)
                {
                    bool isAlreadyAdded = IsMovieInFavorites(user.UserId, movieId);

                    if (!isAlreadyAdded)
                    {
                        Favorites favorite = new Favorites();
                        favorite.MovieId = movieId;
                        favorite.UserId = user.UserId;
                        fm.FavoritesAdd(favorite);
                    }
                }
            

            return RedirectToAction("Index", "Favorites");
        }
        public bool IsMovieInFavorites(int userId, int movieId)
        {
            return fm.GetListByUserId(userId).Any(f => f.MovieId == movieId);
        }
        public ActionResult RemoveFromFavorites(int movieId)
        {
            
                string email = (string)Session["Email"];
                User user = um.GetByEmail(email);

                if (user != null)
                {
                    Favorites favorite = fm.GetByUserAndMovie(user.UserId, movieId);

                    if (favorite != null)
                    {
                        fm.FavoritesDelete(favorite);
                    }
                }
            

            return RedirectToAction("Index", "Favorites");
        }






    }
}
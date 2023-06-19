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
    public class RatingController : Controller
    {
        RatingManager rm = new RatingManager(new EFRatingDal());
        UserManager um = new UserManager(new EFUserDal());
        MovieManager mm = new MovieManager(new EFMovieDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddRating()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRating(Rating rating)
        {
            bool hasRated = rm.HasUserRatedMovie(rating.UserId, rating.MovieId);
            if (!hasRated)
            {
                rm.RatingAdd(rating);

                var movie = mm.GetById(rating.MovieId);
                if (movie != null)
                {
                    movie.AverageRating = CalculateAverageRating(movie.MovieId);
                    mm.MovieUpdate(movie);
                }
            }

            int MovieId = rating.MovieId;
            return RedirectToAction("GetMovie", "AdminMovie", new { id = MovieId });
        }

        public decimal CalculateAverageRating(int movieId)
        {
            var ratings = rm.GetListByMovieId(movieId);
            if (ratings.Count > 0)
            {
                decimal totalRating = ratings.Sum(r => r.Rate);
                decimal averageRating = totalRating / ratings.Count;
                return Math.Round(averageRating, 1);
            }
            else
            {
                return 0;
            }
        }

    }
}
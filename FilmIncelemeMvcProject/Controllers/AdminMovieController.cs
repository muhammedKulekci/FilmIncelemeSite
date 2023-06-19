using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.ValidationRules;
using FilmIncelemeMvcProject.DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmIncelemeMvcProject.Controllers
{
    public class AdminMovieController : Controller
    {
        MovieManager mm = new MovieManager(new EFMovieDal());
        GenreManager gm = new GenreManager(new EFGenreDal());
        CommentManager cm = new CommentManager(new EFCommentDal());
        UserManager um = new UserManager(new EFUserDal());
        RatingManager rm = new RatingManager(new EFRatingDal());

        public ActionResult Index()
        {
            var movieValues = mm.GetList();


            return View(movieValues);
        }





        [HttpGet]
        public ActionResult AddMovie()
        {
            
            List<SelectListItem> valuegenre = (from x in gm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.GenreName,
                                                   Value = x.GenreId.ToString(),
                                               }).ToList();

            ViewBag.vlg = valuegenre;
            return View();
        }
        [HttpPost]
        public ActionResult AddMovie(Movie p)
        {
            List<SelectListItem> valuegenre = (from x in gm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.GenreName,
                                                   Value = x.GenreId.ToString(),
                                               }).ToList();

            ViewBag.vlg = valuegenre;

            MovieValidator movieValidator = new MovieValidator();
            ValidationResult result = movieValidator.Validate(p);
            if (result.IsValid)
            {
                mm.MovieAdd(p);
                return RedirectToAction("index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();

        }
        
        public ActionResult GetMovie(int id)
        {
            string email = (string)Session["Email"];
            User userInfo = um.GetByEmail(email);
            ViewBag.user = userInfo;

            var movieValues = mm.GetById(id);
            var commentValues = cm.GetListByMovieId(id);
            ViewBag.movie = movieValues;
            return View(commentValues);
        }
        public ActionResult DeleteMovie(int id)
        {
            var MovieValue = mm.GetById(id);
            MovieValue.IsStatus = false;
            mm.MovieDelete(MovieValue);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateMovie(int id)
        {
            List<SelectListItem> valuegenre = (from x in gm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.GenreName,
                                                   Value = x.GenreId.ToString(),
                                               }).ToList();
            ViewBag.vlg = valuegenre;
            var MovieValue = mm.GetById(id);
            return View(MovieValue);
        }
        [HttpPost]
        public ActionResult UpdateMovie(Movie p)
        {
            List<SelectListItem> valuegenre = (from x in gm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.GenreName,
                                                   Value = x.GenreId.ToString(),
                                               }).ToList();
            ViewBag.vlg = valuegenre;

            MovieValidator movieValidator = new MovieValidator();
            ValidationResult result = movieValidator.Validate(p);
            if (result.IsValid)
            {
                mm.MovieUpdate(p);
                return RedirectToAction("index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();

        }
        public ActionResult GetMovieByGenreId(int id)
        {
            var MovieValue = mm.GetListByGenreId(id);
            return View(MovieValue);

        }
        public ActionResult NewReleasedMovies()
        {
            var movies = mm.GetList().OrderByDescending(m => m.Year).ToList();
            return View(movies);
        }
        public ActionResult Search(string query)
        {
            query = query.ToLower();

            var movies = mm.GetList()
                .Where(m => m.MovieName.ToLower().Contains(query)
                    || m.Writer.ToLower().Contains(query)
                    || m.Director.ToLower().Contains(query))
                .ToList();

            return View(movies);
        }
        public ActionResult MostRatedMovies()
        {
            var movies = mm.GetList().OrderByDescending(m => m.AverageRating).ToList();
            return View(movies);
        }


    }
}
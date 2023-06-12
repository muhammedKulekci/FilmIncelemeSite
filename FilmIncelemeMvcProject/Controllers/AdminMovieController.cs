using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Concrete;
using FilmIncelemeMvcProject.DataAccessLayer.EntityFramework;
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
            mm.MovieAdd(p);
            return RedirectToAction("index");
        }
        public ActionResult MovieByGenre()
        {
            return View();
        }
        public ActionResult GetMovie(int id)
        {
            var movieValues = mm.GetById(id);
            var commentValues= cm.GetListByMovieId(id);
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
            mm.MovieUpdate(p);
            return RedirectToAction("index");
        }
        public ActionResult GetMovieByGenreId(int id)
        {
            var MovieValue = mm.GetListByGenreId(id);
            return View(MovieValue);

        }
    }
}
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
    public class AdminGenreController : Controller
    {
        GenreManager gm =new GenreManager(new EFGenreDal());
        public ActionResult Index()
        {
            var genrevalues = gm.GetList();
            return View(genrevalues);
        }
        [HttpGet]
        public ActionResult AddGenre() 
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult AddGenre(Genre p)
        {
            GenreValidator genreValidator = new GenreValidator();
            ValidationResult result = genreValidator.Validate(p);
            if (result.IsValid)
            {
                gm.GenreAdd(p);
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
        public ActionResult DeleteGenre(int id)
        {
            var genrevalue=gm.GetById(id);
            genrevalue.IsStatus = false;
            gm.GenreDelete(genrevalue);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult EditGenre(int id)
        {
            var genrevalue = gm.GetById(id);
            return View(genrevalue);
        }
        [HttpPost]
        public ActionResult EditGenre(Genre p)
        {
            gm.GenreUpdate(p);
            return RedirectToAction("index");
        }
        
    }
}

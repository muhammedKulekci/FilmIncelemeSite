using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Concrete;
using FilmIncelemeMvcProject.DataAccessLayer.Concrete;
using FilmIncelemeMvcProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmIncelemeMvcProject.Controllers
{
    
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EFCommentDal());
        UserManager um = new UserManager(new EFUserDal());
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult AddComment()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddComment(Comment p,Movie movie)
        {
            string email = (string)Session["Email"];
            User userInfo = um.GetByEmail(email);
            p.DateTime = DateTime.Now;
            p.MovieId = Convert.ToInt32(Request.Form["MovieId"]);
            p.UserId = userInfo.UserId;
            
            cm.CommentAdd(p);
            return RedirectToAction("GetMovie", "AdminMovie", new { id = movie.MovieId });


        }
        public ActionResult DeleteComment(int id)
        {
            var CommentValue = cm.GetById(id);
            CommentValue.IsStatus = false;
            int MovieId = CommentValue.MovieId;
            cm.CommentDelete(CommentValue);
            return RedirectToAction("GetMovie", "AdminMovie", new { id = MovieId });
        }
    }
}
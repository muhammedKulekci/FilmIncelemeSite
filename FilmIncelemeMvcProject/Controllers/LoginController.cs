using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Concrete;
using FilmIncelemeMvcProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FilmIncelemeMvcProject.Controllers
{
    
    public class LoginController : Controller
    {
        UserManager um = new UserManager(new EFUserDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User p)
        {
            um.GetUser(p);
            if(p != null) 
            {
                FormsAuthentication.SetAuthCookie(p.Email, false);
                Session["Email"] = p.Email;
                return RedirectToAction("Index", "AdminMovie");
            }
            else 
            { 
                return RedirectToAction("index"); 
            }
            
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User p)
        {
            um.UserAdd(p);
            return RedirectToAction("index");
        }
    }
}
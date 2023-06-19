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
                ViewBag.name = "MemedAli";
                return RedirectToAction("Index", "AdminMovie",new {ViewBag.name});
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
            UserValidator userValidator = new UserValidator();
            ValidationResult result = userValidator.Validate(p);
            if (result.IsValid)
            {
                um.UserAdd(p);
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
        public ActionResult Logout()
        {
            
            Session.Clear();

            
            return RedirectToAction("Index");
        }
    }
}
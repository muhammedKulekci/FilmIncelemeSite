using FilmIncelemeMvcProject.BusinessLayer.Concrete;
using FilmIncelemeMvcProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmIncelemeMvcProject.Controllers
{
    public class AdminUserController : Controller
    {
        UserManager um=  new UserManager(new EFUserDal());
        public ActionResult Index()
        {
            var UserValues = um.GetList();
            return View(UserValues);
        }
        public ActionResult DeleteUser(int id)
        {
            var UserValue = um.GetById(id);
            UserValue.IsStatus= false;
            um.UserDelete(UserValue);
            return RedirectToAction("index");
        
        }
    }
}
using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Concrete;
using FilmIncelemeMvcProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public ActionResult UpdateUser()
        {
            string email = (string)Session["Email"];
            User userInfo = um.GetByEmail(email);

            return View(userInfo);
        }

        [HttpPost]
        public ActionResult UpdateUser(User p, IEnumerable<HttpPostedFileBase> Image)
        {
            if (ModelState.IsValid)
            {
                
                foreach (var file in Image)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string filePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                        file.SaveAs(filePath);
                        p.Image = "/Images/" + fileName;
                    }
                    else
                    {
                        p.Image = "/Images/profile.png";
                    }
                }

                
                um.UserUpdate(p);

                return RedirectToAction("UpdateUser");
            }

            return View(p);
        }


    }







}

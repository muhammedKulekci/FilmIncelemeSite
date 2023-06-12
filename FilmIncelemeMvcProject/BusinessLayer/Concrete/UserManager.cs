﻿using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Abstarct;
using FilmIncelemeMvcProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _UserDal;

        public UserManager(IUserDal userDal)
        {
            _UserDal = userDal;
        }

        public User GetById(int id)
        {
            return _UserDal.Get(x=>x.UserId == id);
        }

        public List<User> GetList()
        {
            return _UserDal.List(x => x.IsStatus == true);
        }

        public void UserAdd(User user)
        {
            _UserDal.Insert(user);
        }

        public void UserDelete(User user)
        {
            
            _UserDal.Update(user);
        }

        public void UserUpdate(User user)
        {
            _UserDal.Update(user);
        }
    }
}
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmIncelemeMvcProject.BusinessLayer.Abstarct
{
    public interface IUserService
    {
        List<User> GetList();
        void UserAdd(User user);
        void UserDelete(User user);
        void UserUpdate(User user);
        User GetById(int id);
        User GetUser(User user);
    }
}

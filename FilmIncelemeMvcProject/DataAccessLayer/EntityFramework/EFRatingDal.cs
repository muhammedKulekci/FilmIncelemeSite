using FilmIncelemeMvcProject.DataAccessLayer.Abstract;
using FilmIncelemeMvcProject.DataAccessLayer.Concrete.Repositories;
using FilmIncelemeMvcProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.DataAccessLayer.EntityFramework
{
    public class EFRatingDal : GenericRepository<Rating>, IRatingDal
    {
    }
}
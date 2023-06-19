using EntityLayer.Concrete;
using FilmIncelemeMvcProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmIncelemeMvcProject.BusinessLayer.Abstarct
{
    internal interface IRatingService
    {
        List<Rating> GetList();
        List<Rating> GetListByMovieId(int id);
        void RatingAdd(Rating rating);
        void RatingDelete(Rating rating);
        void RatingUpdate(Rating rating);
        bool HasUserRatedMovie(int userId, int movieId);
        Rating GetById(int id);
    }
}

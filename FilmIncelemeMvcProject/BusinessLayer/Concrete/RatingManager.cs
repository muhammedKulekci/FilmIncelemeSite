using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Abstarct;
using FilmIncelemeMvcProject.DataAccessLayer.Abstract;
using FilmIncelemeMvcProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.BusinessLayer.Concrete
{
    public class RatingManager : IRatingService
    {
        IRatingDal _RatingDal;

        public RatingManager(IRatingDal ratingDal)
        {
            _RatingDal = ratingDal;
        }

        public Rating GetById(int id)
        {
            return _RatingDal.Get(x => x.RatigId == id);
        }

        public List<Rating> GetList()
        {
            return _RatingDal.List();
        }

        public List<Rating> GetListByMovieId(int id)
        {
            return _RatingDal.List(x => x.MovieId == id);
        }

        public bool HasUserRatedMovie(int userId, int movieId)
        {
            var hasRated = _RatingDal.Get(r => r.UserId == userId && r.MovieId == movieId);
            if (hasRated != null) 
            {
                return true;
            } 
            else if(hasRated == null)
            {
                return false;
            }
            return true;

        }

        public void RatingAdd(Rating rating)
        {
            _RatingDal.Insert(rating);
        }

        public void RatingDelete(Rating rating)
        {
            throw new NotImplementedException();
        }

        public void RatingUpdate(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
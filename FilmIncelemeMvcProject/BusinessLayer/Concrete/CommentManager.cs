using EntityLayer.Concrete;
using FilmIncelemeMvcProject.BusinessLayer.Abstarct;
using FilmIncelemeMvcProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public void CommentDelete(Comment comment)
        {
            
            _commentDal.Update(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public Comment GetById(int id)
        {
            return _commentDal.Get(x => x.CommentId == id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List(x=>x.IsStatus==true);
        }

        public List<Comment> GetListByMovieId(int id)
        {
            return _commentDal.List(x => x.MovieId == id && x.IsStatus == true);
        }
    }
}
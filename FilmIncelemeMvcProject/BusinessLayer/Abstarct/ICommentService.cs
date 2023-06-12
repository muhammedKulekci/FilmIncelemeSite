using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmIncelemeMvcProject.BusinessLayer.Abstarct
{
    public interface ICommentService
    {
        List<Comment> GetList();
        List<Comment> GetListByMovieId(int id);
        void CommentAdd(Comment comment);
        Comment GetById(int id);
        void CommentDelete(Comment comment);
        void CommentUpdate(Comment comment);
    }
}


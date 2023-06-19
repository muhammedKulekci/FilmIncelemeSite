using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.EntityLayer.Concrete
{
    public class Favorites
    {
        [Key]
        public int FavoritesId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.EntityLayer.Concrete
{
    public class Rating
    {
        [Key]
        public int RatigId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Rate { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
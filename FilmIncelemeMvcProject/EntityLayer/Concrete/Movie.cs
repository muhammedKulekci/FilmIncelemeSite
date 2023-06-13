using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [StringLength(150)]
        public string MovieName { get; set; }
        [StringLength(100)]
        public string Director { get; set; }
        [StringLength(100)]
        public string Writer { get; set; }
        [StringLength(1000)]
        public string Image { get; set; }
        [StringLength(1000)]
        public string Trailer { get; set; }        
        public int Year { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public bool IsStatus { get; set; } =true;
        public bool IsDelete { get; set; }
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public ICollection<Comment> Comments { get; set; }




    }
}

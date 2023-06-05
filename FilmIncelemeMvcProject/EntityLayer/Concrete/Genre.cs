using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [StringLength(50)]
        public string GenreName { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
    }
}

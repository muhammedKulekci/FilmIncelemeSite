﻿using System;
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
        [StringLength(500)]
        public string Image { get; set; }
        
        public int Year { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Comment> Comments { get; set; }




    }
}
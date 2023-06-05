using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [StringLength(1000)]
        public string CommentText { get; set; }
        public int Rating { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Movie Movie { get; set; }
        public int MovieId { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDeleted { get; set; }
    }
}

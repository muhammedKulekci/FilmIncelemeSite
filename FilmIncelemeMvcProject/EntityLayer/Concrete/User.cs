using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(100)]
        public string NameSurname { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength (300)]
        public string Image { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public bool IsStatus { get; set; } = true;
        public bool IsDeleted { get; set; }

    }
}

using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.BusinessLayer.ValidationRules
{
    public class GenreValidator:AbstractValidator<Genre>
    {
        public GenreValidator() 
        {
            RuleFor(x=>x.GenreName).NotEmpty().WithMessage("Kategori Adını Boş Geçmeyiniz");
            RuleFor(x => x.GenreName).MaximumLength(50).WithMessage("Kategori Adı 50 Karakterden Uzun Olamaz");
        
        }    
    }
}
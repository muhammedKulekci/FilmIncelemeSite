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
            RuleFor(x=>x.GenreName).NotEmpty().WithMessage("Do not leave the name of the category blank");
            RuleFor(x => x.GenreName).MaximumLength(50).WithMessage("Category Name Cannot Be Longer Than 50 Characters");
        
        }    
    }
}
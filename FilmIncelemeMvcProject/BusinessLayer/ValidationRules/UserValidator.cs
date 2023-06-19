using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Name cannot be left blank");
            RuleFor(x => x.NameSurname).MaximumLength(100).WithMessage("Name Cannot Be Longer Than 100 Characters");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be left blank");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("Password Cannot Be Longer Than 20 Characters");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be left blank");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email Cannot Be Longer Than 100 Characters");

            RuleFor(x => x.Image).NotEmpty().WithMessage("Image cannot be left blank");
            RuleFor(x => x.Image).MaximumLength(950).WithMessage("Image Cannot Be Longer Than 950 Characters");
        }
    }
}
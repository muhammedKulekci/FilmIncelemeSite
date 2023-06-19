using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmIncelemeMvcProject.BusinessLayer.ValidationRules
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()

        {
            RuleFor(x => x.MovieName).NotEmpty().WithMessage("Do not leave the name of the movie blank");
            RuleFor(x => x.MovieName).MaximumLength(100).WithMessage("Movie Name Cannot Be Longer Than 100 Characters");

            RuleFor(x => x.Writer).NotEmpty().WithMessage("Do not leave the Writer of the movie blank");
            RuleFor(x => x.Writer).MaximumLength(100).WithMessage("Movie Writer Cannot Be Longer Than 100 Characters");

            RuleFor(x => x.Director).NotEmpty().WithMessage("Do not leave the Director of the movie blank");
            RuleFor(x => x.Director).MaximumLength(100).WithMessage("Movie Director Cannot Be Longer Than 100 Characters");

            RuleFor(x => x.Image).NotEmpty().WithMessage("Do not leave the Image of the movie blank");
            RuleFor(x => x.Image).MaximumLength(1000).WithMessage("Movie Image Cannot Be Longer Than 100 Characters");

            RuleFor(x => x.Trailer).NotEmpty().WithMessage("Do not leave the Trailer of the movie blank");
            RuleFor(x => x.Trailer).MaximumLength(1000).WithMessage("Movie Trailer Cannot Be Longer Than 100 Characters");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Do not leave the Description of the movie blank");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Movie Description Cannot Be Longer Than 100 Characters");

            RuleFor(x => x.Year).NotEmpty().WithMessage("Do not leave the Year of the movie blank");

            RuleFor(x => x.Duration).NotEmpty().WithMessage("Do not leave the Duration of the movie blank");
           

        }
    }
}
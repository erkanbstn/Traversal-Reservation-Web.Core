using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(b=>b.Title).NotEmpty().WithMessage("Title Doesnt Empty.");
            RuleFor(b=>b.Title2).NotEmpty().WithMessage("Title Doesnt Empty.");
            RuleFor(b=>b.Description).NotEmpty().WithMessage("Description Doesnt Empty.");
            RuleFor(b=>b.Title).MinimumLength(10).WithMessage("Please Enter At Least 20 Characters.");
            RuleFor(b=>b.Title2).MinimumLength(10).WithMessage("Please Enter At Least 20 Characters.");
            RuleFor(b=>b.Description).MinimumLength(20).WithMessage("Please Enter At Least 20 Characters.");
            RuleFor(b=>b.Description2).MinimumLength(20).WithMessage("Please Enter At Least 20 Characters.");
            RuleFor(b=>b.Description2).NotEmpty().WithMessage("Description Doesnt Empty.");
        }
    }
}

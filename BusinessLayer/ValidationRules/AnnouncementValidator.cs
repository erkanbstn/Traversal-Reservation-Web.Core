using DataAccessLayer.Migrations;
using DtoLayer.Dtos.AnnouncementDto;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator:AbstractValidator<AnnouncementAddDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content Does Not Empty.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Does Not Empty.");

            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Title Cannot Be Less Than 5 Characters.");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Title Cannot Be Less Than 5 Characters.");

            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Title Cannot Be More Than 100 Characters.");
            RuleFor(x => x.Content).MaximumLength(2000).WithMessage("Title Cannot Be More Than 2000 Characters.");
        }
    }
}

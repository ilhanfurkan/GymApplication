using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class FooterDetailValidator : AbstractValidator<FooterDetail>
    {
        public FooterDetailValidator()
        {
            
            RuleFor(fd => fd.LogoUrl).MaximumLength(60).WithMessage("Maximum 60 characters can be entered.");

            RuleFor(fd => fd.FbUrl).MaximumLength(100).WithMessage("Maximum 100 characters can be entered.");

            RuleFor(fd => fd.IgUrl).MaximumLength(100).WithMessage("Maximum 100 characters can be entered.");

            RuleFor(fd => fd.TwtUrl).MaximumLength(100).WithMessage("Maximum 100 characters can be entered.");

            RuleFor(fd => fd.YtUrl).MaximumLength(100).WithMessage("Maximum 100 characters can be entered.");

            RuleFor(fd => fd.EmUrl).MaximumLength(100).WithMessage("Maximum 100 characters can be entered.");

            RuleFor(fd => fd.TipsTitle).MaximumLength(100).WithMessage("Maximum 100 characters can be entered.");
            RuleFor(fd => fd.TipsTitle).NotEmpty().WithMessage("Cannot be Empty");

            RuleFor(fd => fd.TipsDetail).MaximumLength(100).WithMessage("Maximum 100 characters can be entered.");
            RuleFor(fd => fd.TipsDetail).NotEmpty().WithMessage("Cannot be Empty");
            
        }
    }
}

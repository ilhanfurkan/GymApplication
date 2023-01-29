using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class MenuValidator : AbstractValidator<Menu>
    {
        public MenuValidator()
        {
            RuleFor(mv => mv.MenuName).NotEmpty().WithMessage("Cannot be Empty");

            RuleFor(mv => mv.SeoUrl).NotEmpty().WithMessage("Cannot be Empty");

        }
    }
}

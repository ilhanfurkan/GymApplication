using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class ChoseUsValidator : AbstractValidator<ChoseUs>
    {
        public ChoseUsValidator()
        {
            RuleFor(cuv => cuv.ReasonTitle).NotEmpty().WithMessage("Cannot be Empty");

            RuleFor(cuv => cuv.ReasonDetail).NotEmpty().WithMessage("Cannot be Empty");

            RuleFor(cuv => cuv.ChoseUsIcon).NotEmpty().WithMessage("Cannot be Empty");
        }
    }
}

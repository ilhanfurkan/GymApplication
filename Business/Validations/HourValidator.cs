using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class HourValidator:AbstractValidator<Hour>
    {
        public HourValidator() 
        {
            RuleFor(hour => hour.Hours).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(hour => hour.Hours).MaximumLength(15).WithMessage("en fazla 15 karakter girilir.");

            RuleFor(hour => hour.Time).NotEmpty().WithMessage("Boş geçilemez");



        }
    }
}

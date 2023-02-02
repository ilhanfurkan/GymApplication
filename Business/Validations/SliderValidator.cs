using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class SliderValidator:AbstractValidator<Slider>
    {
        public SliderValidator() 
        {
            
            RuleFor(slider => slider.SliderTitle).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            
            RuleFor(slider => slider.SliderDetail).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");

            RuleFor(slider => slider.SliderImage).NotEmpty().WithMessage("Cannot be Empty");
            
        }
    }
}

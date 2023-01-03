using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.CategoryName).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(category => category.CategoryName).MaximumLength(50).WithMessage("Maximum 50 karakter girilebilir.");
            RuleFor(category => category.CategoryName).MinimumLength(2).WithMessage("Minimum 2 karakter girilmedilir.");
        }
    
    }
}

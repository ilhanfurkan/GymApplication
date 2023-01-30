using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class CompanyContactValidator:AbstractValidator<CompanyContact>
    {
        public CompanyContactValidator() 
        {
            //companycontact Detail
            RuleFor(companyContact => companyContact.CompanyContactDetail).NotEmpty().WithMessage("Cannot be Empty");
			RuleFor(companyContact => companyContact.CompanyContactDetail).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
			RuleFor(companyContact => companyContact.CompanyContactDetail).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");


			//companycontact Icon
			RuleFor(companyContact => companyContact.CompanyContactIcon).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(companyContact => companyContact.CompanyContactIcon).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(companyContact => companyContact.CompanyContactIcon).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");

        }
    }
}

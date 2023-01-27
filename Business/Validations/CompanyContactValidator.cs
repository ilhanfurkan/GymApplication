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
            //companycontact PhoneNo
            RuleFor(companyContact => companyContact.CompanyContactPhoneNo).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(companyContact => companyContact.CompanyContactPhoneNo).MaximumLength(11).WithMessage("Maximum 11 characters can be entered.");
            RuleFor(companyContact => companyContact.CompanyContactPhoneNo).MinimumLength(11).WithMessage("minimum of 11 characters must be entered.");

            //companycontact Mail
            RuleFor(companyContact => companyContact.CompanyContactcMail).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(companyContact => companyContact.CompanyContactcMail).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(companyContact => companyContact.CompanyContactcMail).MinimumLength(10).WithMessage("minimum of 10 characters must be entered.");

            //companycontact address
            RuleFor(companyContact => companyContact.CompanyContactAddress).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(companyContact => companyContact.CompanyContactAddress).MaximumLength(150).WithMessage("Maximum 150 characters can be entered.");
            RuleFor(companyContact => companyContact.CompanyContactAddress).MinimumLength(10).WithMessage("minimum of 10 characters must be entered.");
        }
    }
}

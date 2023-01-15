using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator() 
        {
            RuleFor(admin => admin.AdminName).NotEmpty();
            RuleFor(admin => admin.AdminPassword).NotEmpty();
            RuleFor(admin => admin.Mail).NotEmpty();
            RuleFor(admin => admin.AdminType).NotEmpty();
           
            
            RuleFor(admin => admin.AdminPassword).MinimumLength(8);
            

            
        }

    }
}

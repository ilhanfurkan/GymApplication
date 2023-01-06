using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            //UserLogin
            RuleFor(user => user.UserLogin).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(user => user.UserLogin).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(user => user.UserLogin).MinimumLength(3).WithMessage("minimum of 3 characters must be entered.");

            //UserPassword
            RuleFor(user => user.UserPassword).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(user => user.UserPassword).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(user => user.UserPassword).MinimumLength(7).WithMessage("minimum of 7 characters must be entered.");

            //User FirstName
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(user => user.FirstName).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(user => user.FirstName).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");

            //User LastName
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(user => user.LastName).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(user => user.LastName).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");

            //User Gender
            RuleFor(user => user.Gender).NotNull().WithMessage("Gender Required");

            //User DateOfBirth
            RuleFor(user => user.DateOfBirth).NotEmpty().WithMessage("Cannot be Empty.");

            //User NationalId
            RuleFor(user => user.NationalId).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(user => user.NationalId).MaximumLength(11).WithMessage("Maximum 11 characters can be entered.");
            RuleFor(user => user.NationalId).MinimumLength(11).WithMessage("minimum of 11 characters must be entered.");

            //User Height
            RuleFor(user => user.Height).NotEmpty().WithMessage("Cannot be Empty.");

            //User Weight
            RuleFor(user => user.Weight).NotEmpty().WithMessage("Cannot be Empty.");

            //User PhoneNo
            RuleFor(user => user.PhoneNo).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(user => user.PhoneNo).MaximumLength(11).WithMessage("Maximum 11 characters can be entered.");
            RuleFor(user => user.PhoneNo).MinimumLength(11).WithMessage("minimum of 11 characters must be entered.");

            //User Mail
            RuleFor(user => user.Mail).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(user => user.Mail).MaximumLength(150).WithMessage("Maximum 150 characters can be entered.");
            RuleFor(user => user.Mail).MinimumLength(10).WithMessage("minimum of 10 characters must be entered.");

        }

    }
}

using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class TrainerValidator : AbstractValidator<Trainer>
    {
        public TrainerValidator() 
        {
            //trainerLogin
            RuleFor(trainer => trainer.TrainerLogin).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(trainer => trainer.TrainerLogin).MinimumLength(3).WithMessage("minimum of 3 characters must be entered.");

            //trainerPassword
            RuleFor(trainer => trainer.TrainerPassword).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(trainer => trainer.TrainerPassword).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(trainer => trainer.TrainerPassword).MinimumLength(8).WithMessage("minimum of 8 characters must be entered.");

            //trainer FirstName
            RuleFor(trainer => trainer.TrainerFirstName).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(trainer => trainer.TrainerFirstName).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(trainer => trainer.TrainerFirstName).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");

            //trainer LastName
            RuleFor(trainer => trainer.TrainerLastName).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(trainer => trainer.TrainerLastName).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(trainer => trainer.TrainerLastName).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");

            //trainer NationalId
            RuleFor(trainer => trainer.TrainerNationalId).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(trainer => trainer.TrainerNationalId).MaximumLength(11).WithMessage("Maximum 11 characters can be entered.");
            RuleFor(trainer => trainer.TrainerNationalId).MinimumLength(11).WithMessage("minimum of 11 characters must be entered.");

            //trainer PhoneNo
            RuleFor(trainer => trainer.TrainerPhoneNo).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(trainer => trainer.TrainerPhoneNo).MaximumLength(11).WithMessage("Maximum 11 characters can be entered.");
            RuleFor(trainer => trainer.TrainerPhoneNo).MinimumLength(11).WithMessage("minimum of 11 characters must be entered.");

            //trainer Mail
            RuleFor(trainer => trainer.TrainerMail).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(trainer => trainer.TrainerMail).MaximumLength(150).WithMessage("Maximum 150 characters can be entered.");
            RuleFor(trainer => trainer.TrainerMail).MinimumLength(10).WithMessage("minimum of 10 characters must be entered.");

            //trainer DateOfBirth
            //RuleFor(trainer => trainer.TrainerDateOfBirth).NotEmpty().WithMessage("Cannot be Empty.");



        }
    }
}

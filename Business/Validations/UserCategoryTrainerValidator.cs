using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class UserCategoryTrainerValidator : AbstractValidator<UserCategoryTrainer>
    {
        public UserCategoryTrainerValidator()
        {
            //UserHourTrainer Date
            RuleFor(userCategoryTrainer => userCategoryTrainer.DateOfRegistration).NotEmpty().WithMessage("Cannot be Empty");

            //UserHourTrainer Price
            RuleFor(userCategoryTrainer => userCategoryTrainer.PaymentType).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(userCategoryTrainer => userCategoryTrainer.Price).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(userCategoryTrainer => userCategoryTrainer.Price).GreaterThan(0.00).WithMessage("You must enter a higher price!");

            // UserId And PacketId
            RuleFor(userCategoryTrainer => userCategoryTrainer.UserId).NotEmpty().WithMessage("Cannot be Empty");

            RuleFor(userCategoryTrainer => userCategoryTrainer.PacketId).NotEmpty().WithMessage("Cannot be Empty");

        }
    }
}

using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class UserHourTrainerValidator : AbstractValidator<UserHourTrainer>
    {
        public UserHourTrainerValidator()
        {
            //UserHourTrainer Date
            RuleFor(userHourTrainer => userHourTrainer.Date).NotEmpty().WithMessage("Boş geçilemez");

            //UserHourTrainer Hours
            RuleFor(userHourTrainer => userHourTrainer.Hours).NotEmpty().WithMessage("Boş geçilemez");

            // UserId And SeanceId
            RuleFor(userHourTrainer => userHourTrainer.SeanceId).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(userHourTrainer => userHourTrainer.UserId).NotEmpty().WithMessage("Cannot be Empty");

        }

    }
}

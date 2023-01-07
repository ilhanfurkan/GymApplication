using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class HourTrainerValidator: AbstractValidator<HourTrainer>
    {
        public HourTrainerValidator ()
        {
            //HourTrainer Quota
            RuleFor(HourTrainer => HourTrainer.Quota).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(HourTrainer => HourTrainer.Quota).GreaterThan(0).WithMessage("Should be Greater Than Zero");



            //HourTrainer Date
            RuleFor(HourTrainer => HourTrainer.Date).NotEmpty().WithMessage("Cannot be Empty");

            // HourId And TrainerId
            RuleFor(HourTrainer => HourTrainer.HourId).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(HourTrainer => HourTrainer.TrainerId).NotEmpty().WithMessage("Cannot be Empty");

        }
    }
}

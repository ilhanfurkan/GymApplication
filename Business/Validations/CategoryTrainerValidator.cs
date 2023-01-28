using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class CategoryTrainerValidator : AbstractValidator<CategoryTrainer>
    {
        public CategoryTrainerValidator() 
        {
            RuleFor(categoryTrainer => categoryTrainer.PacketName).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(categoryTrainer => categoryTrainer.PacketName).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(categoryTrainer => categoryTrainer.PacketName).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");

            RuleFor(categoryTrainer => categoryTrainer.PacketDetail).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(categoryTrainer => categoryTrainer.PacketDetail).MaximumLength(150).WithMessage("Maximum 150 characters can be entered.");
            RuleFor(categoryTrainer => categoryTrainer.PacketDetail).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");

            RuleFor(categoryTrainer => categoryTrainer.PacketPrice).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(categoryTrainer => categoryTrainer.PacketPrice).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(categoryTrainer => categoryTrainer.PacketPrice).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");

            RuleFor(categoryTrainer => categoryTrainer.OldPrice).NotEmpty().WithMessage("Cannot be Empty");
            RuleFor(categoryTrainer => categoryTrainer.OldPrice).MaximumLength(50).WithMessage("Maximum 50 characters can be entered.");
            RuleFor(categoryTrainer => categoryTrainer.OldPrice).MinimumLength(2).WithMessage("minimum of 2 characters must be entered.");

            RuleFor(categoryTrainer => categoryTrainer.Right).NotEmpty().WithMessage("Cannot be Empty");

            //// CategoryId And TrainerId
            RuleFor(categoryTrainer => categoryTrainer.CategoryId).NotEmpty().WithMessage("Cannot be Empty");

            RuleFor(categoryTrainer => categoryTrainer.TrainerId).NotEmpty().WithMessage("Cannot be Empty");





        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator() 
        { 
            RuleFor(dish  => dish.Price)
                .GreaterThan(0)
                .WithMessage("Price must be a non-negative number");
            RuleFor(dish => dish.KiloCalories)
               .GreaterThan(0)
               .WithMessage("KiloCalories must be a non-negative number");
        }
    }
}

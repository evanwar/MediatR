using CQR.Aplication.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQR.Entities.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.UnitePrice).GreaterThan(0);
            RuleFor(p => p.UnitInStock).GreaterThanOrEqualTo(0);
        }
    }
}

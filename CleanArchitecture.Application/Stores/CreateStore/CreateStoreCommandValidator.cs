using CleanArchitecture.Application.Orders.CreateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.CreateStore
{
    public class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
    {

        public CreateStoreCommandValidator()
        {
            RuleFor(v => v.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(100).WithMessage("Address must not exceed 100 characters.");

            RuleFor(v => v.BranchNumber)
                .NotEmpty().WithMessage("Branch number is required")
                .GreaterThanOrEqualTo(1).WithMessage("Branch number must be greater than or equal to 1")
                .LessThanOrEqualTo(50).WithMessage("Branch number must not exceed 50");

        }
    }
}

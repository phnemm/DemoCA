using CleanArchitecture.Application.Stores.CreateStore;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.UpdateStore
{
    public class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreCommandValidator()
        {
            RuleFor(v => v.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(100).WithMessage("Address must not exceed 100 characters.");

            RuleFor(v => v.BranchNumber)
                .NotEmpty().WithMessage("Branch number is required")
                .LessThanOrEqualTo(50).WithMessage("Branch number must not exceed 50");
        }
    }
}

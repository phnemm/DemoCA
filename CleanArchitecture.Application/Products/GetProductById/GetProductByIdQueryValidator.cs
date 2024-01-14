using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.GetProductById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        public void ConfigureValidationRules()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Id must not null");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price must not empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not empty");
            RuleFor(x => x.Color).NotEmpty().WithMessage("Color must not empty");
            RuleFor(x => x.Size).NotEmpty().WithMessage("Size must not empty");
        }
    }
}

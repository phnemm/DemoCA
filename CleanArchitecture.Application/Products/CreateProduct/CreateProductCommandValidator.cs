﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
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

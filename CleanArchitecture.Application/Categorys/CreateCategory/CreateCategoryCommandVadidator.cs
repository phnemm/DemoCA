using CleanArchitecture.Application.Category.CreateCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Categorys.CreateCategory
{
    public class CreateCategoryCommandVadidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandVadidator() 
        {
            RuleFor(v => v.Name)
               .NotEmpty().WithMessage("Name is required")
               .MaximumLength(20).WithMessage("Name must not exceed 20 characters.")
               .MinimumLength(5).WithMessage("Name must greater than 5 characters.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
        }
    }
}

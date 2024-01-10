using CleanArchitecture.Application.Users.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is require")
                .MaximumLength(50).WithMessage("Password must not exceed 50 character")
                .MinimumLength(5).WithMessage("Password must greater than 5 characters");
        }
    }
}

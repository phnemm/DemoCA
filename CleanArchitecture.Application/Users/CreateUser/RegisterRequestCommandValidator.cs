using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.CreateUser
{
    public class RegisterRequestCommandValidator : AbstractValidator<RegisterRequestCommand>
    {
        IUserRepository _userRepository;
        public RegisterRequestCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Username)
                .NotEmpty().WithMessage("Username is require")
                .MaximumLength(50).WithMessage("Username must not exceed 50 character")
                .MinimumLength(5).WithMessage("Username must greater than 5 characters")
                .Must(BeUnique).WithMessage("Username is already exist");
        }
        private bool BeUnique(string username)
        {
            return !_userRepository.IsUniqueUsername(username).Result;
        }
    }
}

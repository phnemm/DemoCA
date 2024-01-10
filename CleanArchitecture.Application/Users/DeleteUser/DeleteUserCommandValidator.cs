using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        IUserRepository _userRepository;
        public DeleteUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("UserId is require")
                .Must(CheckExist).WithMessage("UserId is not exist");
        }
        private bool CheckExist(Guid userId)
        {
            var user = _userRepository.FindAsync(x => x.Id == userId).Result;
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}

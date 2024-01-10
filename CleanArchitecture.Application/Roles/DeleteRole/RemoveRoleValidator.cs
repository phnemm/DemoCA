using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.DeleteRole
{
    public class RemoveRoleValidator : AbstractValidator<RemoveRoleCommand>
    {
        public RemoveRoleValidator()
        {
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage("Id must not empty");
        }
    }
}

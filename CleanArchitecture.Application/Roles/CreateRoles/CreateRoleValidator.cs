using CleanArchitecture.Application.Orders.CreateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.CreateRoles
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidator()
        {
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {

        }
    }
}

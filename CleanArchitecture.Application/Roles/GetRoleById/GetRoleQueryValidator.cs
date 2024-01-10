using CleanArchitecture.Application.Authenticate.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.GetRoleById
{
    public class GetRoleQueryValidator : AbstractValidator<GetRoleQuery>
    {
        public GetRoleQueryValidator() 
        { 
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}

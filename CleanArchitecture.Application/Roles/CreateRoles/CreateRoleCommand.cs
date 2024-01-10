using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.CreateRoles
{
    public class CreateRoleCommand : IRequest<Guid>, ICommand
    {
        public CreateRoleCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

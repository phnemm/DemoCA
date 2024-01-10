using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.DeleteRole
{
    public class RemoveRoleCommand : IRequest<RoleDto>, ICommand
    {
        public Guid Id { get; set; }

        public RemoveRoleCommand(Guid id)
        {
            Id = id;
        }
    }
}

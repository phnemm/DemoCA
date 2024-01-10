using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.UpdateRole
{
    public class UpdateRoleCommand : IRequest<RoleDto>, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UpdateRoleCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

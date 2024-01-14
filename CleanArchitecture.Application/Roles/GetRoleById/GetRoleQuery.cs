using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.GetRoleById
{
    public class GetRoleQuery : IRequest<RoleDto>, IQuery
    {
        public Guid Id { get; set; }
        public GetRoleQuery(Guid id)
        {
            Id = id;
        }
    }
}

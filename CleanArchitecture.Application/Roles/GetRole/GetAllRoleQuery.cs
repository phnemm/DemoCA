using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.GetRole
{
    public class GetAllRoleQuery : IRequest<List<RoleDto>>, IQuery
    {
        public GetAllRoleQuery() { }
    }
}

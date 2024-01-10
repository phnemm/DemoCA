using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles
{
    public static class RoleDtoMappingExtension
    {
        public static RoleDto MapToRoleDto(this Domain.Entities.Role role, IMapper mapper) 
            => mapper.Map<RoleDto>(role);
    }
}

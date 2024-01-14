using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles
{
    public class RoleDto : IMapFrom<Domain.Entities.Role>
    {
        public RoleDto() { }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public static RoleDto Create(Guid id, string name)
        {
            return new RoleDto () {
                Id = id,
                Name = name
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Role, RoleDto>();
        }
    }
}

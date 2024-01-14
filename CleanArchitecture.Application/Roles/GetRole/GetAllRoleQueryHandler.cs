using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Roles.GetRoleById;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.GetRole
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<RoleDto>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetAllRoleQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            this._mapper = mapper;
        }

        public async Task<List<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var list = await _roleRepository.FindAllAsync(cancellationToken);
            if (list == null)
                throw new NotFoundException($"Not found {list}");
            List<RoleDto> result = new List<RoleDto>();
            foreach (var role in list)
            {
                var item = role.MapToRoleDto(_mapper);
                result.Add(item);
            }
            return result;
        }

    }
}

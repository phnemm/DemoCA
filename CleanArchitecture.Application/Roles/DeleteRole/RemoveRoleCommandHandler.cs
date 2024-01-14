using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.DeleteRole
{
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand, RoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RemoveRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(RemoveRoleCommand command, CancellationToken cancellationToken) 
        { 
            var result = await _roleRepository.FindAsync(x => x.Id ==  command.Id, cancellationToken);
            if (result == null)
                throw new NotFoundException("Id not found");
            _roleRepository.Remove(result);
            await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result.MapToRoleDto(_mapper);
        } 
    }
}

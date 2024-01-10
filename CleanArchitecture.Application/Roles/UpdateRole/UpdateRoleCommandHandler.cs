using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(UpdateRoleCommand command, CancellationToken cancellationToken) 
        { 
            var result = await _roleRepository.FindAsync(x => x.Id == command.Id, cancellationToken);
            if (result == null)
                throw new NotFoundException("Wrong id");
            result.Name = command.Name;
            _roleRepository.Update(result);
            await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result.MapToRoleDto(_mapper);
        }
    }
}

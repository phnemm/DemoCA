using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Roles.CreateRoles
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
    {
        private IRoleRepository _roleRepository;
        public CreateRoleCommandHandler(IRoleRepository repo)
        {
            _roleRepository = repo;
        }

        public async Task<Guid> Handle(CreateRoleCommand request,  CancellationToken cancellationToken)
        {
            var role = new Role()
            {
                Name = request.Name,
            };
            _roleRepository.Add(role);
            await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return role.Id;
        }
    }
}

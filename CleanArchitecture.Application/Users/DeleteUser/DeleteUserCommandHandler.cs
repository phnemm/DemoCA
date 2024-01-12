using CleanArchitecture.Application.Users.CreateUser;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.FindAsync(x => x.Id == request.UserId).Result;
            _userRepository.Remove(user);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return request.UserId;
        }
    }
}

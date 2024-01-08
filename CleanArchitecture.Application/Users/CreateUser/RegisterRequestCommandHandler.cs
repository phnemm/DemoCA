using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Users.CreateUser
{
    public class RegisterRequestCommandHandler : IRequestHandler<RegisterRequestCommand, Guid>
    {
        IUserRepository _userRepository;
        public RegisterRequestCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> Handle(RegisterRequestCommand request, CancellationToken cancellationToken)
        {
            var User = new Domain.Entities.User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = request.Password,
            };

            _userRepository.Add(User);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return User.Id;
        }
    }
}

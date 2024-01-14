using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.CreateUser
{
    public class RegisterRequestCommandHandler : IRequestHandler<RegisterRequestCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public RegisterRequestCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(RegisterRequestCommand command, CancellationToken cancellationToken)
        {
            var add = new User()
            {
                Username = command.Username,
                Password = command.Password,
            };
            add.RoleId = Guid.Parse("441D0654-FED4-4182-40FF-08DC11C06FC4");
            Thread.Sleep(1000);
            _userRepository.Add(add);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return add.Id;
        }  
    }
}

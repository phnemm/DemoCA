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

namespace CleanArchitecture.Application.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {   
            var User = _userRepository.FindAsync(x => x.Id == request.Id).Result;
            if(User != null) 
            { 
                User.Password = request.Password;
                _userRepository.Update(User);
                await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return User.Id;
            }
            return Guid.Empty;
        }
    }
}

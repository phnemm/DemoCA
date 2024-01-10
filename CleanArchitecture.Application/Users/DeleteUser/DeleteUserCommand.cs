using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest<Guid>, ICommand
    {
        public DeleteUserCommand(Guid userId)
        {

            UserId = userId;

        }
        public Guid UserId { get; set; }
    }
}

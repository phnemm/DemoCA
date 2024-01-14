using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Guid>, ICommand
    {
        public UpdateUserCommand(Guid id, string password)
        {
            Id = id;
            Password = password;
        }

        public Guid Id { get; set; }
        public string Password { get; set; }
    }
}

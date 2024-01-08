using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.CreateUser
{
    public class RegisterRequestCommand : IRequest<Guid>, ICommand
    {
        public RegisterRequestCommand(string username, string password)
        {
               Username = username;
               Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}

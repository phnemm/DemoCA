using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common.Interfaces;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.GetJwtToken
{
    public class GetJwtAuthorizeQuery : IRequest<UserDto>, IQuery
    {
        public GetJwtAuthorizeQuery(string userName, string password) 
        {
            this.userName = userName;
            this.password = password;
        }
        public string userName { get; set; }
        public string password { get; set; }
    }
}

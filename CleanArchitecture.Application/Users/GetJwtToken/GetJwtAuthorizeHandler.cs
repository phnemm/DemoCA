using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.GetJwtToken
{
    public class GetJwtAuthorizeHandler : IRequestHandler<GetJwtAuthorizeQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public GetJwtAuthorizeHandler(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository, IMapper mapper)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<UserDto> Handle(GetJwtAuthorizeQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(
                u => u.Username == request.userName && u.Password == request.password,
                cancellationToken: cancellationToken
                );
            if (user == null)
                throw new NotFoundException($"Could not find UserName '{request.userName}'");
            var token = CreateJwtToken(user.Username);
            var refreshToken = CreateRefreshToken(user.Id);
            var response = user.MapToUserDto(_mapper);
            response.token = token;
            return response;
        }
        private string CreateJwtToken(string userName)
        {
            //Define key
            var Key = "asdfaefalsvlkaslekdvnalskenv";
            var key = Encoding.UTF8.GetBytes(Key);
            var securityKey = new SymmetricSecurityKey(key);
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Handler: khoi tao token
            var tokenHandler = new JwtSecurityTokenHandler(); // Handler de tao ra token, xu ly token -> bien thanh string
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    
                    //new Claim("BookNumber", "1")
                }),
                //Token description: thong tin token
                Audience = "",  //token cua ai
                Issuer = "",    //ai phat hanh token nay               
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credential
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        private RefreshTokenDto CreateRefreshToken(Guid userId)
        {
            var token = Guid.NewGuid().ToString("N");
            //var randomByte = new byte[64];
            ////var tokenHandler = new RNGCryptoServiceProvider();  tham khao them de tang tinh security
            //var token = Convert.ToBase64String(randomByte);
            var refreshToken = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ExpiresTime = DateTime.UtcNow.AddDays(1),
                IsActive = true,
                Token = token
            };
            _refreshTokenRepository.CreateRefreshToken(refreshToken);           
            return refreshToken.MapToRefreshTokenDto(_mapper);
        }
    }
}

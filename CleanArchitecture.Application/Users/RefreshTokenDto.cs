using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users
{
    public class RefreshTokenDto : IMapFrom<Domain.Entities.RefreshToken>
    {
        public RefreshTokenDto() 
        {
        
        }
        public static RefreshTokenDto Create(Guid userId, string token, DateTime expiresTime, bool isActive)
        {
            return new RefreshTokenDto
            {
                UserId = userId,
                Token = token,
                ExpiresTime = expiresTime,
                IsActive = isActive
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.RefreshToken, RefreshTokenDto>();
        }

        public Guid UserId { get; set; }
        public string? Token { get; set; }
        public DateTime ExpiresTime { get; set; }
        public bool IsActive { get; set; }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users
{
    public static class RefreshTokenDtoMappingExtension
    {
        public static RefreshTokenDto MapToRefreshTokenDto(this Domain.Entities.RefreshToken refreshToken, IMapper mapper)
        => mapper.Map<RefreshTokenDto>(refreshToken);
    }
}

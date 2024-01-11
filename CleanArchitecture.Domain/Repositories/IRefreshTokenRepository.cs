using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<RefreshToken?> CreateRefreshToken(RefreshToken refreshToken, CancellationToken cancellationToken = default);
    }
}

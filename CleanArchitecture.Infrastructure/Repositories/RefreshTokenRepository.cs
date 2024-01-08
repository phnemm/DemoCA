using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RefreshTokenRepository : RepositoryBase<RefreshToken, RefreshToken, ApplicationDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<RefreshToken?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<RefreshToken?> CreateRefreshToken(RefreshToken refreshToken, CancellationToken cancellationToken = default)
        {
            Add(refreshToken);
            await SaveChangesAsync();
            return await FindAsync(x => x.Id == refreshToken.Id, cancellationToken);
        }

    }
}

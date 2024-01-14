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
    public class RoleRepository : RepositoryBase<Role, Role, ApplicationDbContext>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<List<Role>> FindAllAsync(Func<IQueryable<Role>, IQueryable<Role>> queryOptions, CancellationToken cancellationToken = default)
        {
            return FindAllAsync(queryOptions, cancellationToken);
        }

        public async Task<Role?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }
    }
}

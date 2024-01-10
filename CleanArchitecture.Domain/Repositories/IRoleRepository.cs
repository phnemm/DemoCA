using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IRoleRepository : IEFRepository<Role, Role>
    {
        Task<List<Role>> FindAllAsync(Func<IQueryable<Role>, IQueryable<Role>> queryOptions, CancellationToken cancellationToken = default);
        Task<Role?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}

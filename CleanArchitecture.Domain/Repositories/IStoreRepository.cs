using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IStoreRepository : IEFRepository<Store, Store>
    {
        Task<Store?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Store>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);

    }
}

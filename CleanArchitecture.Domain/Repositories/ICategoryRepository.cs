using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface ICategoryRepository : IEFRepository<Category , Category>
    {
        Task<Category?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Category>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}

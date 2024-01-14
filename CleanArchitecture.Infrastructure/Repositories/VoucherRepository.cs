using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;

namespace CleanArchitecture.Infrastructure
{
    public class VoucherRepository : RepositoryBase<Voucher, Voucher, ApplicationDbContext>, IVoucherRepository
    {
        public VoucherRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<List<Voucher>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Voucher> FindByIdsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindByIdsAsync(id, cancellationToken);
        }

        public async Task<List<Voucher>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(cancellationToken);
        }
    }
}
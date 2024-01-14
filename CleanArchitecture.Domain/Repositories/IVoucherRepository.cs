using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IVoucherRepository : IEFRepository<Voucher, Voucher>
    {

        Task<List<Voucher>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
        Task<List<Voucher>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Voucher> FindByIdsAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
//namespace CleanArchitecture.Domain.Repositories
//{
//    public interface IUserRepository : IEFRepository<User, User>
//    {
//        Task<User?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

//        Task<List<User>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);

//        Task<User?> FindByUsernameAndPassword(string username, string password, CancellationToken cancellationToken = default);
//    }
//}

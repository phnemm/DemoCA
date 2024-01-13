using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;

namespace CleanArchitecture.Infrastructure
{
    public class UserRepository : RepositoryBase<User, User, ApplicationDbContext>, IUserRepository
    {
        private readonly IRoleRepository _roleRepository;

        public UserRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<User?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<User>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> FindByUsernameAndPassword(string username, string password, CancellationToken cancellationToken = default)
        {
           return await FindAsync(x => x.Username == username && x.Password == password, cancellationToken);
        }

        public async Task<bool> IsUniqueUsername(string username, CancellationToken cancellationToken = default)
        {
            var result = await FindAsync(x => x.Username.Equals(username), cancellationToken);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<User>> GetUserByRole(string name, CancellationToken cancellationToken = default)
        {
            var role = await _roleRepository.FindAsync(r => r.Name.Equals(name), cancellationToken);
            if (role == null)
                throw new NotFoundException($"Not found {name}");
            var list = await FindAllAsync(u => u.RoleId == role.Id, cancellationToken);
            return list;
        }

    }
}
using CleanArchitecture.Domain.Common.Interfaces;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();       
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IVoucherRepository, VoucherRepository>();
            return services;
        }
    }
}
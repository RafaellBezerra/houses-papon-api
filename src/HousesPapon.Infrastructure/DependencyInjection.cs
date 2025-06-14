using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Contract;
using HousesPapon.Domain.Repositories.House;
using HousesPapon.Domain.Repositories.Image;
using HousesPapon.Domain.Repositories.Payment;
using HousesPapon.Domain.Repositories.Tenant;
using HousesPapon.Domain.Repositories.User;
using HousesPapon.Domain.Security.Cookie;
using HousesPapon.Domain.Security.Cryptografy;
using HousesPapon.Infrastructure.DataAccess;
using HousesPapon.Infrastructure.DataAccess.Repositories;
using HousesPapon.Infrastructure.DataAccess.Repositories.CommonUtilities;
using HousesPapon.Infrastructure.Security.Cookies;
using HousesPapon.Infrastructure.Security.Cryptografy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HousesPapon.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);

            services.AddScoped<IPasswordEncripter, PasswordEncripter>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var version = ServerVersion.AutoDetect(connectionString);

            Console.WriteLine(connectionString);
            Console.WriteLine(version);

            services.AddDbContext<HousesPaponDbContext>(x => x.UseMySql(connectionString, version));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReadOnlyExistenceCheckerRepository, ExistenceCheckerRepository>();
            services.AddScoped<ICookieGenerator, CookieGenerator>();
            services.AddHttpContextAccessor();

            services.AddScoped<IHouseReadOnlyRepository, HousesRepository>();
            services.AddScoped<IUserReadOnlyRepository, UsersRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UsersRepository>();

            services.AddScoped<ITenantReadOnlyRepository, TenantsRepository>();
            services.AddScoped<ITenantWriteOnlyRepository, TenantsRepository>();
            services.AddScoped<ITenantUpdateOnlyRepository, TenantsRepository>();

            services.AddScoped<IPaymentReadOnlyRepository, PaymentsRepository>();
            services.AddScoped<IPaymentUpdateOnlyRepository, PaymentsRepository>();
            services.AddScoped<IPaymentWriteOnlyRepository, PaymentsRepository>();

            services.AddScoped<IContractReadOnlyRepository, ContractsRepository>();
            services.AddScoped<IContractUpdateOnlyRepository, ContractsRepository>();
            services.AddScoped<IContractWriteOnlyRepository, ContractsRepository>();

            services.AddScoped<IImageReadOnlyRepository, ImagesRepository>();
            services.AddScoped<IImageWriteOnlyRepository, ImagesRepository>();
        }
    }
}

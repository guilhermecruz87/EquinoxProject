using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity;
using NetDevPack.Identity.Jwt;

namespace Equinox.Infra.CrossCutting.Identity
{
    public static class ApiIdentityConfig
    {
        public static void AddApiIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string strConnection = @"Server=192.168.100.4;Database=UberFit;User Id=sa;Password=GuILh3Rm3_123456;Trusted_Connection=False;MultipleActiveResultSets=true;App=EquinoxApi";

            // Default EF Context for Identity (inside of the NetDevPack.Identity)
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                options.UseSqlServer(strConnection,
                    b => b.MigrationsAssembly("Equinox.Infra.CrossCutting.Identity")));

            // Default Identity configuration from NetDevPack.Identity
            services.AddIdentityConfiguration();

            // Default JWT configuration from NetDevPack.Identity
            services.AddJwtConfiguration(configuration, "AppSettings");
        }
    }
}
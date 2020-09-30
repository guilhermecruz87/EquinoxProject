using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity;

namespace Equinox.Infra.CrossCutting.Identity
{
    public static class WebAppIdentityConfig
    {
        public static void AddWebAppIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string strConnection = @"Server=192.168.100.4;Database=UberFit;User Id=sa;Password=GuILh3Rm3_123456;Trusted_Connection=False;MultipleActiveResultSets=true;App=EquinoxApi";

            // Default EF Context for Identity (inside of the NetDevPack.Identity)
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                SqlServerDbContextOptionsExtensions.UseSqlServer(options, strConnection,
                    b => b.MigrationsAssembly("Equinox.Infra.CrossCutting.Identity")));

            // Default Identity configuration from NetDevPack.Identity
            services.AddIdentityConfiguration();
        }
    }
}
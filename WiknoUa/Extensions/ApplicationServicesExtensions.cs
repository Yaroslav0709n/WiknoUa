using WiknoUa.Data.Repository;
using WiknoUa.Data.Repository.IRepository;

namespace WiknoUa.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ITokenRepository, TokenRepository>();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RI.Auth.Business.Services;
using RI.Auth.DataAccess;

namespace RI.Auth.Business;

public static class DependencyInjections
{
    public static IServiceCollection BootstrapBusiness(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .BootstrapDataAccess(configuration)
            .AddTransient<IPersonService, PersonService>();

        return services;
    }
}
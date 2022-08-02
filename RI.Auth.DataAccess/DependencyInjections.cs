using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RI.Auth.DataAccess.Constants;

namespace RI.Auth.DataAccess;

public static class DependencyInjections
{
    public static IServiceCollection BootstrapDataAccess(this IServiceCollection services,
        IConfiguration configuration)
    {
        var authConnectionString = configuration.GetConnectionString(ConnectionStringConstants.Auth);

        services
            .AddDbContext<AuthContext>(options => options.UseNpgsql(authConnectionString))
            .AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
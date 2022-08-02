using RI.Auth.Business;

namespace RI.Auth;

public sealed class Startup
{
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private IConfiguration _configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .BootstrapBusiness(_configuration)
            .AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app
            .UseHttpsRedirection()
            .UseRouting()
            .UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
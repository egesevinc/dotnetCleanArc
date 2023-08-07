using Dot7.CleanArchitecture.Application.Context;
using Dot7.CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dot7.CleanArchitecture.Infrastructure;

public static class RegisterServices
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyWorldDbContext>(options =>{
            options.UseSqlServer(configuration.GetConnectionString("MyWorldDbConnection"));
        });

        services.AddScoped<IMyWorldDbContext>(options =>{
            return options.GetService<MyWorldDbContext>();
        });

    }
}
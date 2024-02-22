using AccountOwnerServer.Contracts;
using AccountOwnerServer.Repository;
using Entities;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }

    public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("PostgresConnection")));
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IQueryHelper<Owner>, QueryHelper<Owner>>();
        services.AddScoped<IQueryHelper<Account>, QueryHelper<Account>>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }

    public static void ConfigureExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
    }
}
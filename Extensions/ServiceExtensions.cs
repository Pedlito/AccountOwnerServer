using System.Text;
using AccountOwnerServer.Contracts;
using AccountOwnerServer.Repository;
using AccountOwnerServer.Services;
using Entities;
using Entities.Helpers;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

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
        services.AddScoped<IQueryHelper<User>, QueryHelper<User>>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }

    public static void ConfigureExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
    }

    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
    {
        var jwtSection = config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]!));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "localhost:5074",
                    ValidAudience = "localhost:5074",
                    IssuerSigningKey = key
                };
            });
    }

    public static void ConfigureTokenService(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
    }
}
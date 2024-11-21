using ApiColegio.Domain.Abstractions;
using ApiColegio.Domain.Models;
using ApiColegio.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiColegio.Infrastructure.Extensions;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuración del DbContext con MySQL
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        // Registrar AppDbContext como Unit of Work
        services.AddHttpContextAccessor();
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<AppDbContext>());

        return services;
    }
}

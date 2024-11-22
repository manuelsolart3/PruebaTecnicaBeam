using ApiColegio.Application.Abstractions.Behaviors;
using ApiColegio.Application.Authentication;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ApiColegio.Application.Extensions;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(ApplicationServices).Assembly);

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        services.AddValidatorsFromAssembly(typeof(ApplicationServices).Assembly);
        services.AddAutoMapper(typeof(ApplicationServices).Assembly);
        services.AddScoped<JwtTokenService>();

        return services;
    }
}

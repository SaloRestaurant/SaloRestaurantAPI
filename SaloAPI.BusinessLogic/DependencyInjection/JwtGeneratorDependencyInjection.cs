using Microsoft.Extensions.DependencyInjection;
using SaloAPI.Application.Interfaces;
using SaloAPI.Application.Services;

namespace SaloAPI.BusinessLogic.DependencyInjection;

public static class JwtGeneratorDependencyInjection
{
    public static IServiceCollection AddJwtGeneratorServices(
        this IServiceCollection services,
        string mangoJwtSignKey,
        int mangoJwtLifetimeMinutes)
    {
        var jwtGeneratorSettings = new JwtGeneratorSettings(
            mangoJwtSignKey,
            mangoJwtLifetimeMinutes);

        services.AddSingleton<IJwtGeneratorSettings, JwtGeneratorSettings>(_ => jwtGeneratorSettings);
        services.AddScoped<IJwtGenerator, JwtGenerator>(_ => new JwtGenerator(jwtGeneratorSettings));

        return services;
    }
}
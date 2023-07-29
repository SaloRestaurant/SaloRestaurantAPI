using Microsoft.Extensions.DependencyInjection;
using SaloAPI.Application.Interfaces;
using SaloAPI.Application.Services;

namespace SaloAPI.BusinessLogic.DependencyInjection;

public static class JwtGeneratorDependencyInjection
{
    public static IServiceCollection AddJwtGeneratorServices(
        this IServiceCollection services,
        string saloJwtSignKey,
        int saloJwtLifetimeMinutes)
    {
        var jwtGeneratorSettings = new JwtGeneratorSettings(
            saloJwtSignKey,
            saloJwtLifetimeMinutes);

        services.AddSingleton<IJwtGeneratorSettings, JwtGeneratorSettings>(_ => jwtGeneratorSettings);
        services.AddScoped<IJwtGenerator, JwtGenerator>(_ => new JwtGenerator(jwtGeneratorSettings));

        return services;
    }
}
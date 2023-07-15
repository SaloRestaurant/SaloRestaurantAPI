namespace SaloAPI.Application.Interfaces;

public interface IJwtGeneratorSettings
{
    string SaloJwtSignKey { get; }

    int SaloJwtLifetimeMinutes { get; }
}
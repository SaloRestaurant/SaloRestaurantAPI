using SaloAPI.Application.Interfaces;

namespace SaloAPI.Application.Services;

public class JwtGeneratorSettings : IJwtGeneratorSettings
{
    public JwtGeneratorSettings(
        string saloJwtSignKey, 
        int saloJwtLifetimeMinutes)
    {
        SaloJwtSignKey = saloJwtSignKey;
        SaloJwtLifetimeMinutes = saloJwtLifetimeMinutes;
    }

    public string SaloJwtSignKey { get; }
    public int SaloJwtLifetimeMinutes { get; }
}
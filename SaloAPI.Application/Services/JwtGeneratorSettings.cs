using SaloAPI.Application.Interfaces;

namespace SaloAPI.Application.Services;

public class JwtGeneratorSettings : IJwtGeneratorSettings
{
    public JwtGeneratorSettings(
        string saloJwtSignKey,
        int saloJwtLifetimeDays)
    {
        SaloJwtSignKey = saloJwtSignKey;
        SaloJwtLifetimeDays = saloJwtLifetimeDays;
    }

    public string SaloJwtSignKey { get; }
    public int SaloJwtLifetimeDays { get; }
}
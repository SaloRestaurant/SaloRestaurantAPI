using Microsoft.IdentityModel.Tokens;
using SaloAPI.Application.Interfaces;
using SaloAPI.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SaloAPI.Application.Services;

public class JwtGenerator : IJwtGenerator
{
    private readonly IJwtGeneratorSettings jwtGeneratorSettings;
    private readonly SymmetricSecurityKey key;

    public JwtGenerator(IJwtGeneratorSettings jwtGeneratorSettings)
    {
        this.jwtGeneratorSettings = jwtGeneratorSettings;
        var encodedKey = Encoding.UTF8.GetBytes(this.jwtGeneratorSettings.SaloJwtSignKey);
        key = new SymmetricSecurityKey(encodedKey);
    }

    public string GenerateJwtToken(UserEntity userEntity)
    {
        return GenerateJwtToken(userEntity, jwtGeneratorSettings.SaloJwtLifetimeDays);
    }

    private string GenerateJwtToken(UserEntity userEntity, int lifetimeMinutes)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, userEntity.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userEntity.Email),
        };

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(lifetimeMinutes),
            SigningCredentials = credentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
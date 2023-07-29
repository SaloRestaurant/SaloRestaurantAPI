using SaloAPI.Domain.Entities;

namespace SaloAPI.Application.Interfaces;

public interface IJwtGenerator
{
    string GenerateJwtToken(UserEntity userEntity);
}
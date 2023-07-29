using SaloAPI.Domain.Entities;

namespace SaloAPI.Application.Interfaces;

public interface IPasswordService
{
    bool ValidateCredentials(UserEntity user, string currentPassword);

    UserEntity ChangePassword(UserEntity user, string newPassword);
}
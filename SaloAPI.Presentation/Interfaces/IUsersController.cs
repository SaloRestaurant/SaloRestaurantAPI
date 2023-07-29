using Microsoft.AspNetCore.Mvc;
using SaloAPI.BusinessLogic.ApiCommands.Users;

namespace SaloAPI.Presentation.Interfaces;

public interface IUsersController
{
    Task<IActionResult> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken);

    Task<IActionResult> ChangePassword(ChangePasswordRequest request, CancellationToken cancellationToken);
}
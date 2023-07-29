using Microsoft.AspNetCore.Mvc;
using SaloAPI.BusinessLogic.ApiCommands.Sessions;

namespace SaloAPI.Presentation.Interfaces;

public interface ISessionsController
{
    Task<IActionResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
}
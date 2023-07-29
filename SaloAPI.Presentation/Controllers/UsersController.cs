using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaloAPI.Application.Interfaces;
using SaloAPI.BusinessLogic.ApiCommands.Users;
using SaloAPI.BusinessLogic.Responses;
using SaloAPI.Presentation.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaloAPI.Presentation.Controllers;

/// <summary>
///     Controller responsible for User Entity.
/// </summary>
[ApiController]
[Route("api/users")]
public class UsersController : ApiControllerBase<UsersController>, IUsersController
{
    public UsersController(
        IMediator mediator,
        IMapper mapper,
        ICorrelationContext correlationContext,
        ILogger<UsersController> logger)
        : base(mediator, mapper, correlationContext, logger)
    {
    }

    /// <summary>
    ///     Registers user in the system.
    /// </summary>
    /// <param name="request">Request instance.</param>
    /// <param name="cancellationToken">Cancellation token instance.</param>
    /// <returns>Possible codes: 200, 400, 409.</returns>
    [HttpPost("signup")]
    [AllowAnonymous]
    [SwaggerOperation(
        Description = "Registers user in the system.",
        Summary = "Registers user in the system.")]
    [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterRequest request,
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<RegisterCommand>(request);
        return await RequestAsync(command, cancellationToken);
    }

    /// <summary>
    ///     Changes password by current password.
    /// </summary>
    /// <param name="request">Request instance.</param>
    /// <param name="cancellationToken">Cancellation Token Instance.</param>
    [HttpPut("password")]
    [Authorize]
    [SwaggerOperation(
        Description = "Changes password by current password.",
        Summary = "Changes password by current password.")]
    [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> ChangePassword(
        [FromBody] ChangePasswordRequest request,
        CancellationToken cancellationToken)
    {
        var userId = CorrelationContext.GetUserId();

        var command = new ChangePasswordCommand(
            userId,
            request.CurrentPassword,
            request.NewPassword,
            request.RepeatNewPassword);

        return await RequestAsync(command, cancellationToken);
    }
}
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaloAPI.Application.Interfaces;
using SaloAPI.BusinessLogic.ApiCommands.Sessions;
using SaloAPI.BusinessLogic.Responses;
using SaloAPI.Presentation.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaloAPI.Presentation.Controllers;

/// <summary>
///     Controller responsible for Sessions Entity.
/// </summary>
[ApiController]
[Route("api/sessions")]
public class SessionsController : ApiControllerBase<SessionsController>, ISessionsController
{
    public SessionsController(
        IMediator mediator,
        IMapper mapper,
        ICorrelationContext correlationContext,
        ILogger<SessionsController> logger)
        : base(mediator, mapper, correlationContext, logger)
    {
    }

    /// <summary>
    ///     Logins to the system. Returns the access token.
    /// </summary>
    /// <param name="request">LoginRequest instance.</param>
    /// <param name="cancellationToken">Cancellation token instance.</param>
    /// <returns>Possible codes: 200, 400, 409.</returns>
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(
        Description = "Logins to the system. Returns the access token.",
        Summary = "Logins to the system.")]
    [ProducesResponseType(typeof(TokensResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
    {
        var command = Mapper.Map<LoginCommand>(request);
        return await RequestAsync(command, cancellationToken);
    }
}
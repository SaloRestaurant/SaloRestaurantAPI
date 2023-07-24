using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaloAPI.Application.Interfaces;
using SaloAPI.BusinessLogic.ApiQueries.AppInfo;

namespace SaloAPI.Presentation.Controllers;

[ApiController]
[Route("api/app-info")]
[Authorize]
public class AppInfoController : ApiControllerBase<AppInfoController>
{
    public AppInfoController(
        IMediator mediator,
        IMapper mapper,
        ICorrelationContext correlationContext,
        ILogger<AppInfoController> logger) 
        : base(mediator, mapper, correlationContext, logger)
    {
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(GetAppInfoResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAppInfoAsync(CancellationToken cancellationToken)
    {
        var query = new GetAppInfoQuery();

        return await RequestAsync(query, cancellationToken);
    }
}
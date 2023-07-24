using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaloAPI.Application.Interfaces;
using SaloAPI.BusinessLogic.Responses;
using SaloAPI.Domain.Constants;
using SaloAPI.Presentation.Middlewares;
using System.Net;

namespace SaloAPI.Presentation.Controllers;

/// <summary>
///     Base controller class. Encapsulates common logic.
/// </summary>
public class ApiControllerBase<TController> : ControllerBase where TController : ControllerBase
{
    private readonly ILogger<TController> _logger;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ApiControllerBase" /> class.
    /// </summary>
    /// <param name="mediator">Mediator instance.</param>
    /// <param name="mapper">Automapper instance.</param>
    /// <param name="correlationContext">ICorrelationContext instance.</param>
    /// <param name="logger"></param>
    public ApiControllerBase(IMediator mediator, IMapper mapper, ICorrelationContext correlationContext,
        ILogger<TController> logger)
    {
        Mediator = mediator;
        Mapper = mapper;
        CorrelationContext = correlationContext;
        _logger = logger;
    }

    protected IMediator Mediator { get; }

    protected IMapper Mapper { get; }

    protected ICorrelationContext CorrelationContext { get; }

    /// <summary>
    ///     Common request logic over all controllers.
    /// </summary>
    /// <typeparam name="TResponse">Error data structure.</typeparam>
    /// <param name="request">Generic request type.</param>
    /// <param name="cancellationToken">Cancellation token instance.</param>
    /// <returns>A <see cref="Task{TResult}" /> Representing the result of the asynchronous operation.</returns>
    [NonAction]
    protected async Task<IActionResult> RequestAsync<TResponse>(
        IRequest<Result<TResponse>> request,
        CancellationToken cancellationToken) where TResponse : ResponseBase
    {
        var response = await Mediator.Send(request, cancellationToken);

        switch (response.StatusCode)
        {
            case HttpStatusCode.BadRequest:
                LoggingHelper.LoggerError(_logger, GetErrorMessage(response), null);
                return BadRequest(response.Error);
            case HttpStatusCode.Conflict:
                LoggingHelper.LoggerError(_logger, GetErrorMessage(response), null);
                return Conflict(response.Error);
            default:
                return Ok(response.Response);
        }
    }

    private static string GetErrorMessage<TResponse>(Result<TResponse> response) where TResponse : ResponseBase
    {
        var errorDetails = ResponseMessageCodes.ErrorDictionary[ResponseMessageCodes.InvalidRequestModel];
        var loggerMessage = $"ERROR ${response.StatusCode}: \n " +
                            $"Error message: ${response.Error.ErrorMessage}, \n " +
                            $"Error details: ${errorDetails}";

        return loggerMessage;
    }
}
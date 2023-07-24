using FluentValidation;
using SaloAPI.BusinessLogic.Responses;
using SaloAPI.Domain.Constants;
using System.Net;

namespace SaloAPI.Presentation.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> logger;
    private readonly RequestDelegate next;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var errorContext = new ErrorContext(exception.Message, exception)
        {
            StatusCode = exception switch
            {
                ValidationException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            }
        };

        await ReturnErrorResponseAsync(context, errorContext);
    }

    private async Task ReturnErrorResponseAsync(HttpContext context, ErrorContext errorContext)
    {
        var errorDetails = ResponseMessageCodes.ErrorDictionary[ResponseMessageCodes.InvalidRequestModel];
        var loggerMessage = $"ERROR ${errorContext.StatusCode}: \n " +
                            $"Error message: ${errorContext.ErrorMessage}, \n " +
                            $"Error details: ${errorDetails}";

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)errorContext.StatusCode;

        LoggingHelper.LoggerError(logger, loggerMessage, errorContext.Exception);

        await context.Response.WriteAsync(new ErrorResponse
        {
            Success = false,
            ErrorMessage = errorContext.ErrorMessage,
            ErrorDetails = errorDetails,
            StatusCode = errorContext.StatusCode
        }.ToString());
    }
}

public static class HandlingMiddlewareExtenstion
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}

internal sealed class ErrorContext
{
    public ErrorContext(string errorMessage, Exception exception)
    {
        ErrorMessage = errorMessage;
        StatusCode = HttpStatusCode.BadRequest;
        Exception = exception;
    }

    public Exception Exception { get; }

    public HttpStatusCode StatusCode { get; init; }

    public string ErrorMessage { get; }
}
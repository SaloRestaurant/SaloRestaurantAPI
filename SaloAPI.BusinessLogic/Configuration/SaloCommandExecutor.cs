using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SaloAPI.BusinessLogic.Responses;

namespace SaloAPI.BusinessLogic.Configuration;

public static class SaloCommandExecutor
{
    internal static async Task<Result<TResponse>> RequestAsync<TResponse>(
        IRequest<Result<TResponse>> request,
        CancellationToken cancellationToken) where TResponse : ResponseBase
    {
        var scope = SaloCompositionRoot.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var result = await mediator.Send(request, cancellationToken);

        return result;
    }
}
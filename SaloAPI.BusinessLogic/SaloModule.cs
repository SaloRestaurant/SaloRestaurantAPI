using MediatR;
using SaloAPI.BusinessLogic.Configuration;
using SaloAPI.BusinessLogic.Responses;

namespace SaloAPI.BusinessLogic;

public static class SaloModule
{
    public static async Task<Result<TResponse>> RequestAsync<TResponse>(
        IRequest<Result<TResponse>> request,
        CancellationToken cancellationToken) where TResponse : ResponseBase
    {
        var result = await SaloCommandExecutor.RequestAsync(request, cancellationToken);
        return result;
    }
}
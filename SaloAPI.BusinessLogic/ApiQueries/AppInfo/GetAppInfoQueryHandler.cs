using MediatR;
using SaloAPI.Application.Interfaces;
using SaloAPI.BusinessLogic.Responses;

namespace SaloAPI.BusinessLogic.ApiQueries.AppInfo;

public class GetAppInfoQueryHandler : IRequestHandler<GetAppInfoQuery, Result<GetAppInfoResponse>>
{
    private readonly ResponseFactory<GetAppInfoResponse> responseFactory;
    private readonly IVersionService versionService;

    public GetAppInfoQueryHandler(IVersionService versionService, ResponseFactory<GetAppInfoResponse> responseFactory)
    {
        this.versionService = versionService;
        this.responseFactory = responseFactory;
    }

    public Task<Result<GetAppInfoResponse>> Handle(GetAppInfoQuery request, CancellationToken cancellationToken)
    {
        var appInfo = new Models.AppInfo(versionService.GetVersion());

        return Task.FromResult(responseFactory.SuccessResponse(GetAppInfoResponse.FromSuccess(appInfo)));
    }
}
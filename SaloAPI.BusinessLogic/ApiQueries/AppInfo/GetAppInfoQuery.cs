using MediatR;
using SaloAPI.BusinessLogic.Responses;

namespace SaloAPI.BusinessLogic.ApiQueries.AppInfo;

public record GetAppInfoQuery : IRequest<Result<GetAppInfoResponse>>;
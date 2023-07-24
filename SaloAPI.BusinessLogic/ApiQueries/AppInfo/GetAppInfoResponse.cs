using SaloAPI.BusinessLogic.Responses;
using SaloAPI.Domain.Constants;

namespace SaloAPI.BusinessLogic.ApiQueries.AppInfo;

public record GetAppInfoResponse : ResponseBase
{
    public Models.AppInfo AppInfo { get; set; }

    public static GetAppInfoResponse FromSuccess(Models.AppInfo appInfo)
    {
        return new GetAppInfoResponse { Message = ResponseMessageCodes.Success, Success = true, AppInfo = appInfo };
    }
}
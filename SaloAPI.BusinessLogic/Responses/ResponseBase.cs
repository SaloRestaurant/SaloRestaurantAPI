using SaloAPI.Domain.Constants;
using System.ComponentModel;

namespace SaloAPI.BusinessLogic.Responses;

public record ResponseBase
{
    [DefaultValue("SUCCESS")]
    public string Message { get; set; }

    [DefaultValue(true)]
    public bool Success { get; set; }

    public static ResponseBase SuccessResponse => new()
    {
        Message = ResponseMessageCodes.Success,
        Success = true,
    };
}
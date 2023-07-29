using MediatR;
using SaloAPI.BusinessLogic.Responses;

namespace SaloAPI.BusinessLogic.ApiCommands.Users;

public record ChangePasswordCommand(
        Guid UserId,
        string CurrentPassword,
        string NewPassword,
        string RepeatNewPassword)
    : IRequest<Result<ResponseBase>>;
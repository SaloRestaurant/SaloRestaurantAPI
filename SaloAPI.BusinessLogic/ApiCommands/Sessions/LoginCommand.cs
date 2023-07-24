using MediatR;
using SaloAPI.BusinessLogic.Responses;

namespace SaloAPI.BusinessLogic.ApiCommands.Sessions;

public record LoginCommand(string Email, string Password)
    : IRequest<Result<TokensResponse>>;
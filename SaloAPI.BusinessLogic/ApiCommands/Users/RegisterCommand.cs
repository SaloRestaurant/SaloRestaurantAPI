using MediatR;
using SaloAPI.BusinessLogic.Responses;

namespace SaloAPI.BusinessLogic.ApiCommands.Users;

public record RegisterCommand(
        string FirstName,
        string LastName,
        string Password,
        string Email,
        string PhoneNumber)
    : IRequest<Result<TokensResponse>>;
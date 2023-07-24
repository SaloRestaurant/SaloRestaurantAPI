using SaloAPI.BusinessLogic.Models;
using SaloAPI.Domain.Constants;

namespace SaloAPI.BusinessLogic.Responses;

public record TokensResponse : ResponseBase
{
    public Tokens Tokens { get; set; }

    public static TokensResponse FromSuccess(
        string accessToken,
        Guid userId)
    {
        return new TokensResponse
        {
            Message = ResponseMessageCodes.Success,
            Success = true,
            Tokens = new Tokens
            {
                AccessToken = accessToken,
                UserId = userId,
            },
        };
    }
}
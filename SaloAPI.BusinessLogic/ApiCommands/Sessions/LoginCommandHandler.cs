using MediatR;
using Microsoft.EntityFrameworkCore;
using SaloAPI.Application.Interfaces;
using SaloAPI.BusinessLogic.Responses;
using SaloAPI.Domain.Constants;
using SaloAPI.Infrastructure.Database;

namespace SaloAPI.BusinessLogic.ApiCommands.Sessions;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<TokensResponse>>
{
    private readonly IBlobServiceSettings blobServiceSettings;
    private readonly SaloDbContext dbContext;
    private readonly IJwtGenerator jwtGenerator;
    private readonly IJwtGeneratorSettings jwtGeneratorSettings;
    private readonly ResponseFactory<TokensResponse> responseFactory;
    private readonly IPasswordService passwordService;

    public LoginCommandHandler(
        IJwtGenerator jwtGenerator,
        SaloDbContext dbContext,
        ResponseFactory<TokensResponse> responseFactory,
        IJwtGeneratorSettings jwtGeneratorSettings,
        IBlobServiceSettings blobServiceSettings,
        IPasswordService passwordService)
    {
        this.jwtGenerator = jwtGenerator;
        this.dbContext = dbContext;
        this.responseFactory = responseFactory;
        this.jwtGeneratorSettings = jwtGeneratorSettings;
        this.blobServiceSettings = blobServiceSettings;
        this.passwordService = passwordService;
    }

    public async Task<Result<TokensResponse>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .FirstOrDefaultAsync(
                userEntity => userEntity.Email == request.Email,
                cancellationToken);

        if (user == null)
        {
            const string errorMessage = ResponseMessageCodes.InvalidCredentials;
            var details = ResponseMessageCodes.ErrorDictionary[errorMessage];

            return responseFactory.ConflictResponse(errorMessage, details);
        }

        var result = passwordService.ValidateCredentials(user, request.Password);

        if (!result)
        {
            const string errorMessage = ResponseMessageCodes.InvalidCredentials;
            var details = ResponseMessageCodes.ErrorDictionary[errorMessage];

            return responseFactory.ConflictResponse(errorMessage, details);
        }

        var accessToken = jwtGenerator.GenerateJwtToken(user);

        var tokens = TokensResponse.FromSuccess(
            accessToken,
            user.Id);

        return responseFactory.SuccessResponse(tokens);
    }
}
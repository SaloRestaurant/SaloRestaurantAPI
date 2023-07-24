using MediatR;
using Microsoft.EntityFrameworkCore;
using SaloAPI.Application.Interfaces;
using SaloAPI.BusinessLogic.Responses;
using SaloAPI.Domain.Constants;
using SaloAPI.Domain.Entities;
using SaloAPI.Infrastructure.Database;
using System.Security.Cryptography;
using System.Text;

namespace SaloAPI.BusinessLogic.ApiCommands.Users;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<TokensResponse>>
{
    private readonly IBlobServiceSettings blobServiceSettings;
    private readonly SaloDbContext dbContext;
    private readonly IJwtGenerator jwtGenerator;
    private readonly IJwtGeneratorSettings jwtGeneratorSettings;
    private readonly ResponseFactory<TokensResponse> responseFactory;

    public RegisterCommandHandler(
        SaloDbContext dbContext,
        IJwtGenerator jwtGenerator,
        IJwtGeneratorSettings jwtGeneratorSettings,
        ResponseFactory<TokensResponse> responseFactory,
        IBlobServiceSettings blobServiceSettings)
    {
        this.dbContext = dbContext;
        this.responseFactory = responseFactory;
        this.jwtGenerator = jwtGenerator;
        this.jwtGeneratorSettings = jwtGeneratorSettings;
        this.blobServiceSettings = blobServiceSettings;
    }

    public async Task<Result<TokensResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userExists = await dbContext.Users
            .AnyAsync(entity => entity.Email == request.Email, cancellationToken);

        if (userExists)
        {
            const string errorMessage = ResponseMessageCodes.UserAlreadyExists;
            var details = ResponseMessageCodes.ErrorDictionary[errorMessage];

            return responseFactory.ConflictResponse(errorMessage, details);
        }

        var hmac = new HMACSHA512();

        var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        var passwordSalt = hmac.Key;

        var newUser = UserEntity.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            passwordHash,
            passwordSalt);

        dbContext.Users.Add(newUser);

        var accessToken = jwtGenerator.GenerateJwtToken(newUser);

        await dbContext.SaveChangesAsync(cancellationToken);

        var response = TokensResponse.FromSuccess(
            accessToken,
            newUser.Id);

        var result = responseFactory.SuccessResponse(response);

        return result;
    }
}
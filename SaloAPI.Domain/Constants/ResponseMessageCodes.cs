using System.Collections.Immutable;

namespace SaloAPI.Domain.Constants;

public static class ResponseMessageCodes
{
    public const string Unauthorized = "UNAUTHORIZED";
    public const string Success = "SUCCESS";
    public const string UserAlreadyExists = "USER_ALREADY_EXISTS";
    public const string InvalidCredentials = "INVALID_CREDENTIALS";
    public const string UserNotFound = "USER_NOT_FOUND";
    public const string PermissionDenied = "PERMISSION_DENIED";
    public const string InvalidRequestModel = "INVALID_REQUEST_FORMAT";
    public const string TokensNotFound = "TOKENS_NOT_FOUND";

    private static readonly Dictionary<string, string> Dictionary = new()
    {
        { UserAlreadyExists, "User already exists in the system." },
        { InvalidCredentials, "Invalid credentials. Please, enter valid username and password." },
        { UserNotFound, "User not found in the system." },
        { PermissionDenied, "You are not authorized to perform this action." },
        { InvalidRequestModel, "Invalid request format. Correct input data and try again." },
        { TokensNotFound, "Tokens not found. Please login to the system first." },
        { Unauthorized, "User not authorized, please, sign in." }
    };

    public static ImmutableDictionary<string, string> ErrorDictionary => Dictionary.ToImmutableDictionary();
}
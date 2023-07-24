using Microsoft.AspNetCore.Http;
using SaloAPI.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace SaloAPI.Application.Services;

public class CorrelationContext : ICorrelationContext
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public CorrelationContext(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserId()
    {
        var context = httpContextAccessor.HttpContext;

        var correlationContextUserId = context?.User.FindFirst(JwtRegisteredClaimNames.Jti).ToString();

        var parsed = Guid.TryParse(correlationContextUserId, out var parsedUserId);

        return !parsed
            ? throw new InvalidOperationException(
                $"User ID cannot be parsed. {nameof(correlationContextUserId)}.")
            : parsedUserId;
    }
}
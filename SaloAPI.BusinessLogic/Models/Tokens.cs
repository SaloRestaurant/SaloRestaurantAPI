using System.ComponentModel;

namespace SaloAPI.BusinessLogic.Models;

public record Tokens
{
    [DefaultValue("")] public string AccessToken { get; init; }

    [DefaultValue("28aac181-2a67-4d09-a1fc-749fd3705804")]
    public Guid UserId { get; init; }
}
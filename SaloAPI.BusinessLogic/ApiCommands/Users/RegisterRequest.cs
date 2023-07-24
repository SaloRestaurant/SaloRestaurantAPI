using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SaloAPI.BusinessLogic.ApiCommands.Users;

public record RegisterRequest
{
    [JsonConstructor]
    public RegisterRequest(
        string email,
        string password)
    {
        Email = email;
        Password = password;
    }

    [DefaultValue("MyUniqueEmail")] public string Email { get; }

    [DefaultValue("x[?6dME#xrp=nr7q")] public string Password { get; }
}
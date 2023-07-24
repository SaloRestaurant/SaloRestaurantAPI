using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SaloAPI.BusinessLogic.ApiCommands.Sessions;

public record LoginRequest
{
    [JsonConstructor]
    public LoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

    [DefaultValue("MyUniqueEmail")] public string Email { get; }

    [DefaultValue("x[?6dME#xrp=nr7q")] public string Password { get; }
}
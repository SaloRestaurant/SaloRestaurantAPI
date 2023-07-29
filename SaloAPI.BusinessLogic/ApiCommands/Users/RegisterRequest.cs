using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SaloAPI.BusinessLogic.ApiCommands.Users;

public record RegisterRequest
{
    [JsonConstructor]
    public RegisterRequest(
        string firstName,
        string lastName,
        string password,
        string email,
        string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
    }

    [DefaultValue("Egor")] public string FirstName { get; set; }

    [DefaultValue("Egorius")] public string LastName { get; set; }

    [DefaultValue("+380961112233")] public string PhoneNumber { get; set; }

    [DefaultValue("MyUniqueEmail")] public string Email { get; }

    [DefaultValue("x[?6dME#xrp=nr7q")] public string Password { get; }
}
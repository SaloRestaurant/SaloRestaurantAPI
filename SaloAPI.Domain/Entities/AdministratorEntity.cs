using FluentValidation;

namespace SaloAPI.Domain.Entities;

public sealed class AdministratorEntity
{
    public AdministratorEntity()
    {
    }

    public AdministratorEntity(
        string firstName,
        string lastName,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt)
    {
        Id = Guid.NewGuid();

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;

        new AdministratorEntityValidator().ValidateAndThrow(this);
    }

    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public static AdministratorEntity Create(
        string firstName,
        string lastName,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt)
    {
        var newAdmin = new AdministratorEntity(firstName, lastName, email, passwordHash, passwordSalt);

        return newAdmin;
    }
}
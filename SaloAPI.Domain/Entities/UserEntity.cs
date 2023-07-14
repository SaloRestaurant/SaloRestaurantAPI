using FluentValidation;

namespace SaloAPI.Domain.Entities;

public sealed class UserEntity
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public byte[] PasswordHash { get; set; }
    
    public byte[] PasswordSalt { get; set; }

    public UserEntity()
    {
    }
    
    public UserEntity(
        string firstName, 
        string lastName, 
        string email, 
        string phoneNumber, 
        byte[] passwordHash, 
        byte[] passwordSalt)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        
        new UserEntityValidator().ValidateAndThrow(this);
    }

    public static UserEntity Create(
        string firstName, 
        string lastName, 
        string email, 
        string phoneNumber, 
        byte[] passwordHash, 
        byte[] passwordSalt)
    {
        var newUser = new UserEntity(firstName, lastName, email, phoneNumber, passwordHash, passwordSalt);

        return newUser;
    }
}
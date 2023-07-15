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

    public ICollection<DeliveryAddressEntity> DeliveryAddresses => _deliveryAddresses;
    private readonly List<DeliveryAddressEntity> _deliveryAddresses;
    
    public ICollection<OrderEntity> Orders => _orders;
    private readonly List<OrderEntity> _orders;

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
        _deliveryAddresses = new List<DeliveryAddressEntity>();
        _orders = new List<OrderEntity>();
        
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
    
    public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;

        new UserEntityValidator().ValidateAndThrow(this);
    }
}
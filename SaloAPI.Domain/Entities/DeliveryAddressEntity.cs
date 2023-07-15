using FluentValidation;

namespace SaloAPI.Domain.Entities;

public sealed class DeliveryAddressEntity
{
    public Guid Id { get; set; }
    
    public string Address { get; set; }
    
    public string District { get; set; }
    
    public string City { get; set; }
    
    public string ZipCode { get; set; }
    
    public string AdditionalInfo { get; set; }
    
    public Guid? UserId { get; set; }
    
    public UserEntity UserEntity { get; set; }

    public DeliveryAddressEntity()
    {
    }
    
    public DeliveryAddressEntity(
        string address, 
        string district, 
        string city, 
        string zipCode, 
        string additionalInfo, 
        Guid? userId)
    {
        Id = Guid.NewGuid();
        
        Address = address;
        District = district;
        City = city;
        ZipCode = zipCode;
        AdditionalInfo = additionalInfo;
        UserId = userId;

        new DeliveryAddressEntityValidator().ValidateAndThrow(this);
    }

    public static DeliveryAddressEntity Create(
        string address,
        string district,
        string city,
        string zipCode,
        string additionalInfo,
        Guid? userId)
    {
        var newAddress = new DeliveryAddressEntity(address, district, city, zipCode, additionalInfo, userId);

        return newAddress;
    }
}
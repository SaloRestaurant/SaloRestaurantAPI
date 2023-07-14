using FluentValidation;

namespace SaloAPI.Domain.Entities;

public sealed class ProductEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Price { get; set; }
    
    public int Quantity { get; set; }
    
    public Guid? CategoryId { get; set; }

    public ProductEntity()
    {
    }
    
    public ProductEntity(
        string name, 
        string description, 
        int price, 
        int quantity, 
        Guid? categoryId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        CategoryId = categoryId;
        
        new ProductEntityValidator().ValidateAndThrow(this);
    }

    public static ProductEntity Create(
        string name,
        string description,
        int price,
        int quantity,
        Guid? categoryId)
    {
        var newProduct = new ProductEntity(name, description, price, quantity, categoryId);

        return newProduct;
    }
}
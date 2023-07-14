using FluentValidation;

namespace SaloAPI.Domain.Entities;

public sealed class CategoryEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public CategoryEntity()
    {
    }

    public CategoryEntity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        
        new CategoryEntityValidator().ValidateAndThrow(this);
    }

    public static CategoryEntity Create(string name)
    {
        var newCategory = new CategoryEntity(name);
        
        return newCategory;
    }
}
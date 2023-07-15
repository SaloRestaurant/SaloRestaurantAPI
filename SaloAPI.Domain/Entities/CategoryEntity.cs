﻿using FluentValidation;

namespace SaloAPI.Domain.Entities;

public sealed class CategoryEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public ICollection<ProductEntity> Products => _products;
    private readonly List<ProductEntity> _products;

    public CategoryEntity()
    {
    }

    public CategoryEntity(string name)
    {
        Id = Guid.NewGuid();
        _products = new List<ProductEntity>();
        
        Name = name;
        
        new CategoryEntityValidator().ValidateAndThrow(this);
    }

    public static CategoryEntity Create(string name)
    {
        var newCategory = new CategoryEntity(name);
        
        return newCategory;
    }
}
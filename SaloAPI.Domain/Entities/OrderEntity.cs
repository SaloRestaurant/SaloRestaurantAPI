using FluentValidation;
using SaloAPI.Domain.Enums;

namespace SaloAPI.Domain.Entities;

public sealed class OrderEntity
{
    public Guid Id { get; set; }
    
    public DateTime? Date { get; set; }
    
    public OrderStatus? Status { get; set; }
    
    public int Total { get; set; }
    
    public Guid? UserId { get; set; }

    public OrderEntity()
    {
    }
    
    public OrderEntity(
        DateTime? date, 
        OrderStatus? status, 
        int total, 
        Guid? userId)
    {
        Id = Guid.NewGuid();
        Date = date;
        Status = status;
        Total = total;
        UserId = userId;
        
        new OrderEntityValidator().ValidateAndThrow(this);
    }

    public static OrderEntity Create(
        DateTime? date, 
        OrderStatus? status, 
        int total, 
        Guid? userId)
    {
        var newOrder = new OrderEntity(date, status, total, userId);

        return newOrder;
    }
}
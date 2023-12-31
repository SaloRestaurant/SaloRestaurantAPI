﻿using FluentValidation;
using SaloAPI.Domain.Enums;

namespace SaloAPI.Domain.Entities;

public sealed class OrderEntity
{
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

    public Guid Id { get; set; }

    public DateTime? Date { get; set; }

    public OrderStatus? Status { get; set; }

    public int Total { get; set; }

    public Guid? UserId { get; set; }

    public UserEntity UserEntity { get; set; }

    public OrderDetailsEntity OrderDetailsEntity { get; set; }

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
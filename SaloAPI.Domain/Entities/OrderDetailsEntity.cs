namespace SaloAPI.Domain.Entities;

public class OrderDetailsEntity
{
    public OrderDetailsEntity()
    {
    }

    public OrderDetailsEntity(
        int quantity,
        Guid? orderId,
        Guid? productId)
    {
        Id = Guid.NewGuid();

        Quantity = quantity;
        OrderId = orderId;
        ProductId = productId;
    }

    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ProductId { get; set; }

    public OrderEntity OrderEntity { get; set; }

    public ProductEntity ProductEntity { get; set; }

    public static OrderDetailsEntity Create(
        int quantity,
        Guid? orderId,
        Guid? productId)
    {
        var newOrderDetail = new OrderDetailsEntity(quantity, orderId, productId);

        return newOrderDetail;
    }
}
using Fanap.Shop.Domain.Entities;

namespace Fanap.Shop.Appliction.Dtos;

public record OrderDto(Guid CustomerId, string Product, int Quantity, decimal TotalAmount, DateTime OrderDate);

public static class OrderMapper
{
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto(
            order.CustomerId,
            order.Product,
            order.Quantity,
            order.TotalAmount,
            order.OrderDate
        );
    }
}


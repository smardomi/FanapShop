using Fanap.Shop.Domain.Common;
using Fanap.Shop.Domain.Exceptions;

namespace Fanap.Shop.Domain.Entities;

public class Order
{
    private Order(Guid customerId, string product, int quantity, decimal totalAmount)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        Product = product;
        Quantity = quantity;
        TotalAmount = totalAmount;
        OrderDate = DateTime.UtcNow;
    }

    protected Order() { }

    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public string Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal TotalAmount { get; private set; }
    public DateTime OrderDate { get; private set; }

    public static Order Create(Guid customerId, string product, int quantity, decimal pricePerUnit)
    {
        if (quantity <= 0) throw new QuantityMustBeGreaterThanZeroException();
        if (pricePerUnit < 0) throw new PriceMustBeNonNegativeException();
        var total = quantity * pricePerUnit;
        return new Order(customerId, product, quantity, total);
    }
}

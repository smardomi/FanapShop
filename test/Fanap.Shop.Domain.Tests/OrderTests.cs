using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Exceptions;
namespace Fanap.Shop.Domain.Tests;

public class OrderTests
{
    [Fact]
    public void CreateOrder_WithPositiveTotal_Succeeds()
    {
        var order = Order.Create(Guid.NewGuid(), "Product X", 2, 50m);
        Assert.True(order.TotalAmount > 0);
    }

    [Fact]
    public void CreateOrder_Throws_WhenQuantityInvalid()
    {
        Assert.Throws<QuantityMustBeGreaterThanZeroException>(() => Order.Create(Guid.NewGuid(), "P", 0, 1000000));
    }
}

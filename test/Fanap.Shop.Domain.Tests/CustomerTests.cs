using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Exceptions;

namespace Fanap.Shop.Domain.Tests;

public class CustomerTests
{
    [Fact]
    public void AddFunds_ShouldIncreaseWalletBalance()
    {
        var customer = new Customer("Saeed", "Mardomi", "saeedmardomi@hotmail.com", "Customer");

        customer.AddFunds(1000000);

        Assert.Equal(1000000, customer.WalletBalance);
    }


    [Fact]
    public void DeductFunds_ShouldThrow_WhenBalanceIsInsufficient()
    {
        var customer = new Customer("Saeed", "Mardomi", "saeedmardomi@hotmail.com", "Customer");

        Assert.Throws<AmountExceedsWalletBalanceException>(() => customer.DeductFunds(50));
    }

    [Fact]
    public void DeductFunds_ShouldDecreasesWalletBalance()
    {
        var customer = new Customer("Saeed", "Mardomi", "saeedmardomi@hotmail.com", "Customer");
        customer.AddFunds(1000000);
        customer.DeductFunds(500000);
        Assert.Equal(500000, customer.WalletBalance);
    }

}

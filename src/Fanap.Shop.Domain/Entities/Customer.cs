using Fanap.Shop.Domain.Exceptions;

namespace Fanap.Shop.Domain.Entities;

public class Customer : User
{
    private readonly List<TransactionRecord> _transactions = new();

    public Customer(string firstName, string lastName, string email, string password) : base(firstName, lastName, email, password)
    {
        WalletBalance = 0;
    }

    protected Customer() { }

    public decimal WalletBalance { get; private set; }
    public IReadOnlyCollection<TransactionRecord> Transactions => _transactions.AsReadOnly();

    public void AddFunds(decimal amount)
    {
        AddTransaction(amount,"واریز به کیف پول");
        WalletBalance += amount;
    }

    public void DeductFunds(decimal amount)
    {
        if (amount > WalletBalance)
            throw new AmountExceedsWalletBalanceException();

        AddTransaction(amount * -1, "برداشت از کیف پول");

        WalletBalance -= amount;
    }

    public void AddTransaction(decimal amount, string description)
    {
        _transactions.Add(new TransactionRecord(DateTime.UtcNow, amount, description));
    }
}

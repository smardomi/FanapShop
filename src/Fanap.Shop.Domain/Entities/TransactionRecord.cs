namespace Fanap.Shop.Domain.Entities;

public class TransactionRecord
{
    public TransactionRecord(DateTime date, decimal amount, string description)
    {
        Date = date;
        Amount = amount;
        Description = description;
    }

    protected TransactionRecord() { }

    public DateTime Date { get; private set; }
    public decimal Amount { get; private set; }
    public string Description { get; private set; }
   
}

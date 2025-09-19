using Fanap.Shop.Domain.Enums;
using Fanap.Shop.Domain.Exceptions;

namespace Fanap.Shop.Domain.Entities;

public class Invoice
{ 

    public Invoice(Guid orderId, decimal amount, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        Amount = amount;
        DueDate = dueDate;
        Status = InvoiceStatus.Pending;
    }

    protected Invoice() { }


    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public InvoiceStatus Status { get; private set; }

    public void MarkAsPaid()
    {
        if (Status == InvoiceStatus.Paid) throw new InvoiceAlreadyPaidException();
        Status = InvoiceStatus.Paid;
    }
}

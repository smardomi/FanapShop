using Fanap.Shop.Domain.Common;
using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Enums;
using Fanap.Shop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fanap.Shop.Domain.Tests;

public class InvoiceTests
{
    [Fact]
    public void NewInvoice_IsPending()
    {
        var invoice = new Invoice(Guid.NewGuid(), 10000000, DateTime.UtcNow.AddDays(7));
        Assert.Equal(InvoiceStatus.Pending, invoice.Status);
    }

    [Fact]
    public void MarkAsPaid_ChangesStatusToPaid()
    {
        var invoice = new Invoice(Guid.NewGuid(), 300m, DateTime.UtcNow.AddDays(1));
        invoice.MarkAsPaid();
        Assert.Equal(InvoiceStatus.Paid, invoice.Status);
    }

    [Fact]
    public void MarkAsPaid_Throws_WhenAlreadyPaid()
    {
        var invoice = new Invoice(Guid.NewGuid(), 300m, DateTime.UtcNow.AddDays(1));
        invoice.MarkAsPaid();
        Assert.Throws<InvoiceAlreadyPaidException>(() => invoice.MarkAsPaid());
    }
}

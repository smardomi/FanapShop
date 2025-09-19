using Fanap.Shop.Domain.Entities;

namespace Fanap.Shop.Appliction.Dtos;

public record InvoiceDto(
 Guid OrderId,
 decimal Amount,
 DateTime DueDate,
 string Status
);

public static class InvoiceMapper
{
    public static InvoiceDto ToDto(this Invoice invoice)
        => new InvoiceDto(
            invoice.OrderId,
            invoice.Amount,
            invoice.DueDate,
            invoice.Status.ToString()
        );
}


using MediatR;

namespace Fanap.Shop.Appliction.Features.Invoices.Commands.CreateInvoice;

public record CreateInvoiceCommand(Guid OrderId, Guid CustomerId, DateTime DueDate) : IRequest;

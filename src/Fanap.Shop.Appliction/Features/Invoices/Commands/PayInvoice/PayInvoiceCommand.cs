using MediatR;
namespace Fanap.Shop.Appliction.Features.Invoices.Commands.PayInvoice;

public record PayInvoiceCommand(Guid InvoiceId, Guid CustomerId) : IRequest;

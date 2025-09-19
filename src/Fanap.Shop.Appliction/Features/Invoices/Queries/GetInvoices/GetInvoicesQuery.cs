using Fanap.Shop.Appliction.Dtos;
using MediatR;

namespace Fanap.Shop.Appliction.Features.Invoices.Queries.GetInvoices;

public record GetInvoicesQuery : IRequest<List<InvoiceDto>>;


using Fanap.Shop.Appliction.Dtos;
using Fanap.Shop.Appliction.Extensions;
using Fanap.Shop.Appliction.Infra;
using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Fanap.Shop.Appliction.Features.Invoices.Queries.GetInvoices;

public class GetInvoiceQueryHandler(IInvoiceRepository invoiceRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetInvoicesQuery, List<InvoiceDto>>
{
    public async Task<List<InvoiceDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        var user = httpContextAccessor.HttpContext?.User
              ?? throw new UnauthorizedAccessException();

        var role = user.GetRole();
        var userId = user.GetUserId();

        List<Invoice> invoiceList;

        if (role == nameof(Admin))
        {
            invoiceList = await invoiceRepository.GetAllAsync(cancellationToken);
        }
        else if (role == nameof(Customer) && userId.HasValue)
        {
            invoiceList = await invoiceRepository.GetAllByCustomerIdAsync(userId.Value, cancellationToken)
                          ?? new List<Invoice>();
        }
        else
        {
            throw new UnauthorizedAccessException();
        }

        return invoiceList
            .OrderByDescending(o => o.DueDate)
            .Select(o => o.ToDto())
            .ToList();
    }
}

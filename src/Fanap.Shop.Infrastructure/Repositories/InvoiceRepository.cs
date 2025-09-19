using Fanap.Shop.Appliction.Infra;
using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Services;
using Fanap.Shop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fanap.Shop.Infrastructure.Repositories;

public class InvoiceRepository(AppDbContext dbContext) : IInvoiceRepository
{
    public async Task CreateAsync(Invoice invoice, CancellationToken cancellationToken)
    {
        await dbContext.Invoices.AddAsync(invoice,cancellationToken);
    }

    public async Task<List<Invoice>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Invoices.AsNoTracking().ToListAsync();
    }

    public async Task<List<Invoice>> GetAllByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
    {
        return await(
           from invoice in dbContext.Invoices
           join order in dbContext.Orders
               on invoice.OrderId equals order.Id
           where order.CustomerId == customerId
           select invoice
       ).ToListAsync(cancellationToken);
    }

    public async Task<Invoice?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Invoices.SingleOrDefaultAsync(x => x.Id == id,cancellationToken);
    }

    public void Update(Invoice invoice)
    {
        dbContext.Invoices.Update(invoice);
    }
}

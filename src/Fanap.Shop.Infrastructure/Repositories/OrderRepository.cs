using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Services;
using Fanap.Shop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fanap.Shop.Infrastructure.Repositories;

public class OrderRepository(AppDbContext dbContext) : IOrderRepository
{
    public async Task CreateAsync(Order order, CancellationToken cancellationToken)
    {
         await dbContext.Orders.AddAsync(order,cancellationToken);
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Orders.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<List<Order>> GetAllByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
    {
        return await dbContext.Orders.Where(a=>a.CustomerId == customerId).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Orders.SingleOrDefaultAsync(o => o.Id == id,cancellationToken);
    }
}

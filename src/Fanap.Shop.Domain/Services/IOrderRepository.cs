using Fanap.Shop.Domain.Entities;

namespace Fanap.Shop.Domain.Services;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Order>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<Order>> GetAllByCustomerIdAsync(Guid customerId,CancellationToken cancellationToken);
    Task CreateAsync(Order order, CancellationToken cancellationToken);
}


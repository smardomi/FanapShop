using Fanap.Shop.Domain.Entities;

namespace Fanap.Shop.Domain.Services;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Update(Customer user);
    Task<List<Customer>> GetAllAsync();
}


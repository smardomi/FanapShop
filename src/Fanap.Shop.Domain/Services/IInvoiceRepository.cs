using Fanap.Shop.Domain.Entities;

namespace Fanap.Shop.Domain.Services;

public interface IInvoiceRepository
{
    Task CreateAsync(Invoice invoice, CancellationToken cancellationToken);
    Task<Invoice?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Invoice>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<Invoice>> GetAllByCustomerIdAsync(Guid customerId,CancellationToken cancellationToken);
    void Update(Invoice invoice);
}


using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Services;
using Fanap.Shop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fanap.Shop.Infrastructure.Repositories;

public class CustomerRepository(AppDbContext dbContext) : ICustomerRepository
{
    public async Task<List<Customer>> GetAllAsync()
    {
       return await dbContext.Users.OfType<Customer>().AsNoTracking().ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Users
                          .OfType<Customer>() 
                          .SingleOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public void Update(Customer user)
    {
        dbContext.Users.Update(user);
    }
}

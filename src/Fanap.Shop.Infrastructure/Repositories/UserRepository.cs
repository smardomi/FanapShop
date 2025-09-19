using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Services;
using Fanap.Shop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fanap.Shop.Infrastructure.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task<List<User>> GetAllAsync()
    {
        return await dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await dbContext.Users.SingleOrDefaultAsync(a=>a.Email == email,cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Users.SingleOrDefaultAsync(a => a.Id == id,cancellationToken);
    }
}

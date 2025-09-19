using Fanap.Shop.Domain.Entities;

namespace Fanap.Shop.Domain.Services;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<User>> GetAllAsync();
}


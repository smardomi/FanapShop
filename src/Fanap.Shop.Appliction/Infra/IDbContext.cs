namespace Fanap.Shop.Appliction.Infra;

public interface IDbContext : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

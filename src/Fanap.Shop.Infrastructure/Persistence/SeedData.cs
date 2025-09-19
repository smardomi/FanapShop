using Fanap.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fanap.Shop.Infrastructure.Persistence;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.Migrate();

        if (!context.Users.Any())
        {
            var admin = new Admin("Fanap", "Admin", "admin@fanap.com", "Admin123");

            var customer = new Customer("Fanap", "Customer", "customer@fanap.com", "Customer123");

            context.Users.Add(admin);
            context.Users.Add(customer);
            context.SaveChanges();
        }
    }
}

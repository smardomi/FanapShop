using Fanap.Shop.Appliction.Infra;
using Fanap.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Fanap.Shop.Infrastructure.Persistence;

public class AppDbContext : DbContext, IDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
           .HasDiscriminator<string>("Role")
           .HasValue<Admin>(nameof(Admin))
           .HasValue<Customer>(nameof(Customer));

        modelBuilder.Entity<User>(b =>
        {
            b.HasKey(c => c.Id);
            b.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            b.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            b.Property(c => c.Email).IsRequired().HasMaxLength(100);
            b.Property(c => c.PasswordHash).IsRequired().HasMaxLength(500);
        });

        modelBuilder.Entity<Customer>()
            .Property(c => c.WalletBalance)
            .IsRequired();

        modelBuilder.Entity<Customer>(b =>
        {
            b.OwnsMany(c => c.Transactions, t =>
            {
                t.ToJson(); 
            });
        });

        modelBuilder.Entity<Order>(b =>
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Product);
            b.Property(o => o.Quantity);
            b.Property(o => o.TotalAmount);
            b.Property(o => o.OrderDate);
            b.Property(o => o.CustomerId);
        });

        modelBuilder.Entity<Invoice>(b =>
        {
            b.HasKey(i => i.Id);
            b.Property(i => i.OrderId);
            b.Property(i => i.Amount);
            b.Property(i => i.DueDate);
            b.Property(i => i.Status);
        });
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
}

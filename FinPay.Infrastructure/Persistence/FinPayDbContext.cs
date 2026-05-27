using FinPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinPay.Infrastructure.Persistence;

public class FinPayDbContext(DbContextOptions<FinPayDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinPayDbContext).Assembly);
    }
}
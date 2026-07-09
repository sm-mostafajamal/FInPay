using FinApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Infrastructure.Persistence;

public class FinAppDbContext(DbContextOptions<FinAppDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinAppDbContext).Assembly);
    }
}
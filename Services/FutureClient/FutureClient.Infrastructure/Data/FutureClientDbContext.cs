using System.Reflection;
using FutureClient.Domain.Entities;
using FutureClient.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FutureClient.Infrastructure.Data;

public class FutureClientDbContext : DbContext
{
    public FutureClientDbContext(DbContextOptions<FutureClientDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<FutureDifference> FutureQuarterDifferences { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FutureQuarterDifferencesConfiguration());
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
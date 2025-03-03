using FutureClient.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FutureClient.Infrastructure.Data;

public class FutureClientDbContext : DbContext
{
    public FutureClientDbContext(DbContextOptions<FutureClientDbContext> options) : base(options)
    {
        
    }
    public DbSet<FutureDifference> FutureQuarterDifferences { get; set; }
}
using FutureClient.Domain.Entities;
using FutureClient.Domain.Repositories;
using FutureClient.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FutureClient.Infrastructure.Repositories;

public class FutureRepository : IFutureRepository
{
    private readonly FutureClientDbContext _dbContext;
    
    public FutureRepository(FutureClientDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddQuarterFutureDifferenceAsync(FutureDifference item)
    {
        await _dbContext.FutureQuarterDifferences.AddAsync(item);
    }

    public async Task<IEnumerable<FutureDifference>> GetAllQuarterFutureDifferenceAsync()
    {
        return await _dbContext
            .FutureQuarterDifferences
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync() >= 0;
    }
}
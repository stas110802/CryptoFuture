using FutureClient.Domain.Entities;
using FutureClient.Domain.Repositories;

namespace FutureClient.Infrastructure.Repositories;

public class FutureRepository : IFutureRepository
{
    public async Task AddQuarterFutureDifferenceAsync(FutureDifference item)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
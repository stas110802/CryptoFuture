using FutureClient.Domain.Entities;

namespace FutureClient.Domain.Repositories;

public interface IFutureRepository
{
    Task AddQuarterFutureDifferenceAsync(FutureDifference item);
    Task<IEnumerable<FutureDifference>> GetAllQuarterFutureDifferenceAsync();
    Task<bool> SaveChangesAsync();
}
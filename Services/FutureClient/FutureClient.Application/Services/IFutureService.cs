using FutureClient.Application.Dtos;
using FutureClient.Domain.Types;

namespace FutureClient.Application.Services;

public interface IFutureService
{
    Task<FutureDifferenceServiceDto> CalculateQuarterFutureDifferenceAsync(string pair, IntervalType interval,
        DateTime? startTime = null, DateTime? endTime = null);
}
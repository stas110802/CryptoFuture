using FutureClient.Application.Dtos;
using FutureClient.Domain.Entities;

namespace FutureClient.Application.Mappers;

public static class FutureServiceMapper
{
    public static FutureDifference MapToFutureDifference(FutureDifferenceServiceDto futureDifference)
    {
        return new FutureDifference
        {
            Date = futureDifference.Date,
            StartTime = futureDifference.StartTime,
            EndTime = futureDifference.EndTime,
            Currency = futureDifference.Currency,
            CurrentQuarterPrice = futureDifference.CurrentQuarterPrice,
            NextQuarterPrice = futureDifference.NextQuarterPrice,
            Difference = futureDifference.Difference
        };
    }
    
    public static FutureDifferenceReadDto MapToFutureDifferenceReadDto(FutureDifferenceServiceDto futureDifference)
    {
        return new FutureDifferenceReadDto
        {
            Currency = futureDifference.Currency,
            Difference = futureDifference.Difference
        };
    }
    
    public static FutureDifferenceReadDto MapToFutureDifferenceReadDto(FutureDifference futureDifference)
    {
        return new FutureDifferenceReadDto
        {
            Currency = futureDifference.Currency,
            Difference = futureDifference.Difference
        };
    }
}
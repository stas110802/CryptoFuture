using FutureClient.Application.Dtos;
using FutureClient.Application.Mappers;
using FutureClient.Application.Services;
using FutureClient.Application.Types;
using FutureClient.Domain.Options;
using FutureClient.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FutureClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FutureClientController : Controller
{
    private readonly IFutureService _futureService;
    private readonly IFutureRepository _futureRepository;

    public FutureClientController(IFutureService futureService, IFutureRepository futureRepository)
    {
        _futureService = futureService;
        _futureRepository = futureRepository;
    }

    [HttpGet]
    public async Task<ActionResult<FutureDifferenceReadDto>> GetQuarterFutureDifference([FromQuery] string currency,
        [FromQuery] string interval, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var intervalType = IntervalType.GetPropertyValue(interval);
        if(intervalType == null)
            return BadRequest("Invalid Interval Type");
        
        var result = await _futureService.CalculateQuarterFutureDifferenceAsync(currency, intervalType, startDate, endDate);
        
        var dbFutureDifference = FutureServiceMapper.MapToFutureDifference(result);
        //await _futureRepository.AddQuarterFutureDifferenceAsync(dbFutureDifference);
        //await _futureRepository.SaveChangesAsync();
        
        var readDto = FutureServiceMapper.MapToFutureDifferenceReadDto(result);
        
        return Ok(readDto);
    }
}
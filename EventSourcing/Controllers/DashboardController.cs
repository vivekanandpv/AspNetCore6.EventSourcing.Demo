using EventSourcing.Models;
using EventSourcing.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly IDashboardAggregateService _aggregateService;
    private readonly IDashboardEventSourcingService _eventSourcingService;

    public DashboardController(IDashboardAggregateService aggregateService, IDashboardEventSourcingService eventSourcingService)
    {
        _aggregateService = aggregateService;
        _eventSourcingService = eventSourcingService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _aggregateService.GetLatestAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Update(DashboardAggregate aggregate)
    {
        await _eventSourcingService.PublishAsync(aggregate);
        return Ok();
    }
}
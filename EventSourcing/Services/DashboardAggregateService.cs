using EventSourcing.DataAccess;
using EventSourcing.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EventSourcing.Services;

class DashboardAggregateService : IDashboardAggregateService
{
    private readonly DashboardContext _context;

    public DashboardAggregateService(DashboardContext context)
    {
        _context = context;
    }

    public async Task<DashboardAggregate> GetLatestAsync()
    {
        var latestEvent = await _context.DashboardEvents.OrderByDescending(e => e.Timestamp).FirstAsync();

        return JsonConvert.DeserializeObject<DashboardAggregate>(latestEvent.Data);
    }
}
using EventSourcing.DataAccess;
using EventSourcing.Models;
using Newtonsoft.Json;

namespace EventSourcing.Services;

class DashboardEventSourcingService : IDashboardEventSourcingService
{
    private readonly DashboardContext _context;

    public DashboardEventSourcingService(DashboardContext context)
    {
        _context = context;
    }

    public async Task PublishAsync(DashboardAggregate aggregate)
    {
        var jsonString = JsonConvert.SerializeObject(aggregate);
        var eventToPublish = new DashboardEvent
        {
            Data = jsonString,
            Timestamp = DateTime.Now,
            ActionId = "Random",
            EventId = Guid.NewGuid().ToString()
        };

        await _context.AddAsync(eventToPublish);

        await _context.SaveChangesAsync();
    }
}
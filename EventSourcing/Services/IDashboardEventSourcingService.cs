using EventSourcing.Models;

namespace EventSourcing.Services;

public interface IDashboardEventSourcingService
{
    Task PublishAsync(DashboardAggregate aggregate);
}
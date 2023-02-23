using EventSourcing.Models;

namespace EventSourcing.Services;

public interface IDashboardAggregateService
{
    Task<DashboardAggregate> GetLatestAsync();
}
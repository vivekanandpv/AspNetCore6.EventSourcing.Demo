namespace EventSourcing.Models;

public class DashboardEvent
{
    public string EventId { get; set; }
    public DateTime Timestamp { get; set; }
    public string ActionId { get; set; }
    public string Data { get; set; }
}
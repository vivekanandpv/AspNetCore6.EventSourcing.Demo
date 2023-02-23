using EventSourcing.DataAccess;
using EventSourcing.Models;
using EventSourcing.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DashboardContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddControllers();
builder.Services.AddScoped<IDashboardAggregateService, DashboardAggregateService>();
builder.Services.AddScoped<IDashboardEventSourcingService, DashboardEventSourcingService>();

var app = builder.Build();

app.MapControllers();

app.Run();
using Microsoft.EntityFrameworkCore;
using TripService.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddDbContext<TripDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TripDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

app.MapGet("/", () => "TripService is running");

app.MapGet("/trips", async (TripDbContext db) =>
    await db.Trips.ToListAsync());

app.Run();
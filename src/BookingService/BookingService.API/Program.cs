using Microsoft.EntityFrameworkCore;
using BookingService.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BookingDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

app.MapGet("/", () => "BookingService is running");

app.MapGet("/bookings", async (BookingDbContext db) =>
    await db.Bookings.ToListAsync());

app.Run();
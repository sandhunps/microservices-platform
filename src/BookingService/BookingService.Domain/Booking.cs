namespace BookingService.Domain;

public class Booking
{
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int Seats { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

namespace CarRent.Application.Dtos.Bookings;

public class CreateBookingDto
{
    public int CarId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

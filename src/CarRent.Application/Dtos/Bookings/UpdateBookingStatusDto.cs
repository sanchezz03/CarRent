using CarRent.Common.Enums;

namespace CarRent.Application.Dtos.Bookings;

public class UpdateBookingStatusDto
{
    public long BookingId { get; set; }
    public BookingStatus Status { get; set; }
}

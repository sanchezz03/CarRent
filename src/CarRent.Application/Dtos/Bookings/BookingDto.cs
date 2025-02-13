using CarRent.Application.Dtos.Payments;
using CarRent.Common.Enums;

namespace CarRent.Application.Dtos.Bookings;

public class BookingDto
{
    public long Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Status { get; set; }

    public int CarId { get; set; }
    public string CarBrand { get; set; } = string.Empty;
    public string CarModel { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public PaymentDto? Payment { get; set; }
}

using CarRent.Common.Enums;

namespace CarRent.Application.Dtos.Filters;

public class BookingFilterDto
{
    public string? UserId { get; set; }
    public int? CarId { get; set; }
    public BookingStatus? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

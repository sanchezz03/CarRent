using CarRent.Common.Enums;

namespace CarRent.Domain.Entities;

public class Booking : Base<long>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.Pending;

    #region Navigation Properties

    public long CarId { get; set; }
    public Car Car { get; set; } = null!;

    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = null!;

    public Payment? Payment { get; set; }

    #endregion
}

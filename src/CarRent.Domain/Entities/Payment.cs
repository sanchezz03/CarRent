using CarRent.Common.Enums;

namespace CarRent.Domain.Entities;

public class Payment : Base<long>
{
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public DateTime Date { get; set; }

    #region Navigation Properties

    public long BookingId { get; set; }
    public Booking Booking { get; set; }

    #endregion
}

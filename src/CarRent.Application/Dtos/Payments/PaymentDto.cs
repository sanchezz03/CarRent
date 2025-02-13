using CarRent.Common.Enums;

namespace CarRent.Application.Dtos.Payments;

public class PaymentDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public int Method { get; set; }
    public DateTime Date { get; set; }
    public long BookingId { get; set; }
}

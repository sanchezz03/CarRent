using CarRent.Common.Enums;

namespace CarRent.Domain.Entities;

public class Car : Base<long>
{
    public string Brand { get; set; } 
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public CarStatus Status { get; set; } = CarStatus.Available;

    #region Navigation Properties

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    #endregion
}

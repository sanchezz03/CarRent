using CarRent.Common.Enums;

namespace CarRent.Application.Dtos.Cars;

public class CarDto
{
    public long Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public int Status { get; set; }
}

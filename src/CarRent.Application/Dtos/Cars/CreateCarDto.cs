namespace CarRent.Application.Dtos.Cars;

public class CreateCarDto
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
}

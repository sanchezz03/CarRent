namespace CarRent.Client.ViewModels;

public class CarVM
{
    public long Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public int Status { get; set; }
}

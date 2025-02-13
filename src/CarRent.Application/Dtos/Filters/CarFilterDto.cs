using CarRent.Common.Enums;

namespace CarRent.Application.Dtos.Filters;

public class CarFilterDto
{
    public string? Brand { get; set; }
    public CarStatus? Status { get; set; }
}
